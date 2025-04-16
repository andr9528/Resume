using Resume.Localization.Abstractions;
using Resume.Services.Abstractions;

namespace Resume.Presentation.Core;

public abstract class BasePage : Page
{
    protected BasePage()
    {
        App = (App) Application.Current;

        try
        {
            if (App.Startup.ServiceProvider == null)
            {
                throw new NullReferenceException(
                    $"Failed to acquire an instance of '{nameof(IServiceProvider)}' from '{nameof(App.Startup)}'!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private App App { get; }

    protected ILocaleService GetLocaleService()
    {
        try
        {
            return App.Startup.ServiceProvider.GetService<ILocaleService>() ??
                   throw new NullReferenceException(
                       $"Failed to acquire an instance implementing '{nameof(ILocaleService)}'.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    protected IEntityService GetEntityService()
    {
        try
        {
            return App.Startup.ServiceProvider.GetService<IEntityService>() ??
                   throw new NullReferenceException(
                       $"Failed to acquire an instance implementing '{nameof(IEntityService)}'.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    protected IOptions<AppConfig> GetAppInfo()
    {
        try
        {
            return App.Startup.ServiceProvider.GetService<IOptions<AppConfig>>() ??
                   throw new NullReferenceException(
                       $"Failed to acquire an instance implementing '{nameof(IOptions<AppConfig>)}'.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    protected ILocalizationCategories GetLocalizationCategories()
    {
        try
        {
            return App.Startup.ServiceProvider.GetService<ILocalizationCategories>() ??
                   throw new NullReferenceException(
                       $"Failed to acquire an instance implementing '{nameof(ILocalizationCategories)}'.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
