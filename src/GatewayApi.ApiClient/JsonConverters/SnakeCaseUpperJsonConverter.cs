using System.Text.Json;
using System.Text.Json.Serialization;

namespace GatewayApi.ApiClient.JsonConverters;

internal class SnakeCaseUpperJsonConverter<TEnum> : JsonStringEnumConverter<TEnum>
    where TEnum : struct, Enum
{
    public SnakeCaseUpperJsonConverter()
        : base(JsonNamingPolicy.SnakeCaseUpper, allowIntegerValues: false) { }
}
