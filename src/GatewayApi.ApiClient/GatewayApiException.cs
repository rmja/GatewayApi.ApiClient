namespace GatewayApi.ApiClient;

public class GatewayApiException(int statusCode, string responseBody) : Exception
{
    public int StatusCode { get; } = statusCode;
    public string ResponseBody { get; } = responseBody;
}
