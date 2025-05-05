using System.Text.Json.Serialization;
using GatewayApi.ApiClient.Sms;

namespace GatewayApi.ApiClient;

[JsonSerializable(typeof(SmsMessage))]
[JsonSerializable(typeof(SendSmsResponse))]
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower)]
internal sealed partial class GatewayApiJsonSerializerContext : JsonSerializerContext;
