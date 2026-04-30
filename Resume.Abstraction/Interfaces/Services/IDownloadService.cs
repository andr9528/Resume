using Microsoft.Extensions.Logging;

namespace Resume.Abstraction.Interfaces.Services;

public interface IDownloadService
{
    Task DownloadResumePdf(Func<string, string, Task> downloadAction);
}
