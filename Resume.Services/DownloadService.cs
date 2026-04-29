using Microsoft.Extensions.Logging;
using Resume.Abstraction.Enums;
using Resume.Abstraction.Interfaces.Services;

namespace Resume.Services;

public class DownloadService : IDownloadService
{
    private const string DANISH_PDF = "Resume - Dansk - André Steenhoff Madsen.pdf";
    private const string ENGLISH_PDF = "Resume - English - André Steenhoff Madsen.pdf";
    private readonly ILocaleService localeService;
    private readonly ILogger<DownloadService> logger;

    public DownloadService(ILocaleService localeService, ILogger<DownloadService> logger)
    {
        this.localeService = localeService;
        this.logger = logger;
    }

    /// <inheritdoc />
    /// <inheritdoc />
    public async Task DownloadResumePdf(Func<string, string, Task> downloadAction)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(downloadAction);

            var fileName = localeService.GetCurrentLanguageType() switch
            {
                LanguageType.DANISH => DANISH_PDF,
                LanguageType.ENGLISH => ENGLISH_PDF,
                _ => throw new ArgumentException("Received an unexpected language when requesting download."),
            };

            logger.LogInformation("Downloading: {FileName}", fileName);

            var relativeUrl = $"Pdfs/{Uri.EscapeDataString(fileName)}";

            logger.LogInformation("Executing download action. RelativeUrl: {RelativeUrl}, FileName: {FileName}",
                relativeUrl, fileName);

            await downloadAction(relativeUrl, fileName);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Caught exception while attempting to download pdf.");
            throw;
        }
    }
}
