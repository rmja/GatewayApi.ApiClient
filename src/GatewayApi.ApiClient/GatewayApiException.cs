namespace GatewayApi.ApiClient;

public class GatewayApiException(int statusCode) : Exception
{
    public int StatusCode { get; } = statusCode;
}
