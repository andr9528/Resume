using Resume.Entities;
using Resume.Entities.Abstractions;
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

    /// <inheritdoc />
    public IProfile GetProfile()
    {
        return new Profile()
        {
            Description = localeService.GetLocalizedString(categories.ProfileKeys.Description),
            Name = localeService.GetLocalizedString(categories.ProfileKeys.Name),
        };
    }
}
