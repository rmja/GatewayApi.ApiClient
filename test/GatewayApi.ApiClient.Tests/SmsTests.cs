using System.Text.Json;
using GatewayApi.ApiClient.Sms;

namespace GatewayApi.ApiClient.Tests;

public class SmsTests(ApiFixture fixture) : IClassFixture<ApiFixture>
{
    private readonly IGatewayApiClient _client = fixture.Client;

    [Fact]
    public void CanSerializeSmsMessage()
    {
        // Given
        var sms = new SmsMessage
        {
            Class = SmsClass.Premium,
            Message = "Test 123",
            Sender = "Sender",
            Priority = SmsPriority.Urgent,
            Recipients = { new(4511223344) }
        };

        // When
        var json = JsonSerializer.Serialize(sms, GatewayApiJsonSerializerOptions.Value);

        // Then
        Assert.Equal(
            "{\"class\":\"premium\",\"message\":\"Test 123\",\"sender\":\"Sender\",\"priority\":\"URGENT\",\"recipients\":[{\"msisdn\":4511223344}]}",
            json
        );
    }

    [Fact(Skip = "Avoid sms spam")]
    public async Task CanSendSmsMessage()
    {
        if (!fixture.TestRecipient.HasValue)
        {
            Assert.Fail("No test recipient configured");
        }

        // Given
        var sms = new SmsMessage
        {
            Message = "Gateway API test",
            Sender = "Sender",
            Recipients = { new(fixture.TestRecipient.Value) }
        };

        // When
        var response = await _client.Sms.SendSmsAsync(sms);

        // Then
        Assert.NotEqual(0, Assert.Single(response.Ids));
    }
}
