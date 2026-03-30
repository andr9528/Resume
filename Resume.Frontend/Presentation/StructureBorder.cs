using Resume.Abstraction.Enums;
using Resume.Abstraction.Interfaces.Keys;
using Resume.Frontend.Presentation.Core;
using Resume.Services.Abstractions;

namespace Resume.Frontend.Presentation;

public partial class StructureBorder : Border
{
    public StructureBorder(
        LanguageType type, ILocaleService localeService, IEntityService entityService,
        ILocalizationCategories categories)
    {
        DataContext = new StructureBorderViewModel();

        var logic = new StructureBorderLogic((StructureBorderViewModel) DataContext);
        var ui = new StructureBorderUi(logic, (StructureBorderViewModel) DataContext, localeService, categories,
            entityService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateScrollView());
    }
}
