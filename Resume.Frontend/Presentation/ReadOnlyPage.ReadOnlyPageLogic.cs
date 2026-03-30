using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation;

public partial class ReadOnlyPage
{
    private class ReadOnlyPageLogic : BaseLogic<ReadOnlyPageViewModel>
    {
        public ReadOnlyPageLogic(ReadOnlyPageViewModel viewModel) : base(viewModel)
        {
        }
    }
}
