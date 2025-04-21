using Resume.Localization.Abstractions;
using Resume.Services.Abstractions;

namespace Resume.Services;

public class EntityService : IEntityService
{
    private readonly ILocaleService localeService;
    private readonly ILocalizationCategories categories;

    public EntityService(ILocaleService localeService, ILocalizationCategories categories)
    {
        this.localeService = localeService;
        this.categories = categories;
    }
}
