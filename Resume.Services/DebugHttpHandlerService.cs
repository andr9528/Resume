using Microsoft.Extensions.Logging;

namespace Resume.Services;

internal class DebugHttpHandlerService : DelegatingHandler
{
    private readonly ILogger _logger;

    public DebugHttpHandlerService(ILogger<DebugHttpHandlerService> logger, HttpMessageHandler? innerHandler = null) :
        base(innerHandler ?? new HttpClientHandler())
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
#if DEBUG
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogDebugMessage("Unsuccessful API Call");
            if (request.RequestUri is not null)
            {
                _logger.LogDebugMessage($"{request.RequestUri} ({request.Method})");
            }

            foreach ((string key, string values) in request.Headers.ToDictionary(x => x.Key,
                         x => string.Join(", ", x.Value)))
            {
                _logger.LogDebugMessage($"{key}: {values}");
            }

            string? content = request.Content is not null ? await request.Content.ReadAsStringAsync() : null;
            if (!string.IsNullOrEmpty(content))
            {
                _logger.LogDebugMessage(content);
            }

            // Uncomment to automatically break when an API call fails while debugging
            // System.Diagnostics.Debugger.Break();
        }
#endif
        return response;
    }
}
