using System.Text.Json.Serialization;
using GatewayApi.ApiClient.JsonConverters;

namespace GatewayApi.ApiClient.Sms;

[JsonConverter(typeof(SnakeCaseLowerJsonConverter<SmsClass>))]
public enum SmsClass
{
    Standard,
    Premium,
    Secret,
}
