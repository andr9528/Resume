using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation.Section;

public partial class LinksSection
{
    private class LinksSectionLogic : BaseLogic<LinksSectionViewModel>
    {
        public LinksSectionLogic(LinksSectionViewModel viewModel) : base(viewModel)
        {
        }
    }
}
