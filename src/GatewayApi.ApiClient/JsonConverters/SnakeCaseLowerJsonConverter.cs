using System.Text.Json;
using System.Text.Json.Serialization;

namespace GatewayApi.ApiClient.JsonConverters;

internal class SnakeCaseLowerJsonConverter<TEnum> : JsonStringEnumConverter<TEnum>
    where TEnum : struct, Enum
{
    public SnakeCaseLowerJsonConverter()
        : base(JsonNamingPolicy.SnakeCaseLower, allowIntegerValues: false) { }
}
