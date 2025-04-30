using GatewayApi.ApiClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

public static class GatewayApiExtensions
{
    public static IServiceCollection AddGatewayApiClient(
        this IServiceCollection services,
        Action<GatewayApiOptions> configureOptions
    )
    {
        services.AddHttpClient<GatewayApiClient>();
        services.TryAddTransient<IGatewayApiClient>(provider =>
        {
            var httpClient = provider
                .GetRequiredService<IHttpClientFactory>()
                .CreateClient(nameof(GatewayApiClient));
            var options = provider.GetRequiredService<IOptions<GatewayApiOptions>>();
            var token = options.Value.Token;
            return new GatewayApiClient(httpClient, token);
        });

        services.Configure(configureOptions);
        return services;
    }
}
