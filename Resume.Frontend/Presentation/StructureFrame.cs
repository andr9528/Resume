using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation;

public partial class StructureFrame : Frame
{
    public StructureFrame(IEntityService entityService)
    {
        DataContext = new StructureFrameViewModel();

        Margin = new Thickness(0);

        var logic = new StructureFrameLogic((StructureFrameViewModel) DataContext);
        var ui = new StructureFrameUi(logic, (StructureFrameViewModel) DataContext, entityService);

        this.Background(Theme.Brushes.Background.Default).Content(ui.CreateScrollView());
    }
}
