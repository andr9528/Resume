using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation;

public partial class StructureFrame : Frame
{
    public StructureFrame(IEntityService entityService, ILocaleService localeService)
    {
        DataContext = new StructureFrameViewModel();

        Margin = new Thickness(0);

        var logic = new StructureFrameLogic((StructureFrameViewModel) DataContext);
        var ui = new StructureFrameUi(logic, (StructureFrameViewModel) DataContext, entityService, localeService);

        this.Background(Theme.Brushes.Background.Default).Content(ui.CreateScrollView());
    }
}
