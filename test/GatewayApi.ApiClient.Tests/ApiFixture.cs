using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GatewayApi.ApiClient.Tests;

public class ApiFixture
{
    public IGatewayApiClient Client { get; }
    public long? TestRecipient { get; }

    public ApiFixture()
    {
        var config = new ConfigurationBuilder().AddUserSecrets<ApiFixture>().Build();
        var services = new ServiceCollection()
            .AddGatewayApiClient(options =>
            {
                options.Token = config["GatewayApiToken"]!;
            })
            .BuildServiceProvider();
        Client = services.GetRequiredService<IGatewayApiClient>();
        var testRecipient = config["TestRecipient"];
        if (testRecipient is not null)
        {
            TestRecipient = long.Parse(testRecipient);
        }
    }
}
