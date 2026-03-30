using Resume.Presentation.Core;

namespace Resume.Presentation;

public partial class ReadOnlyPage
{
    private class ReadOnlyPageLogic : BaseLogic<ReadOnlyPageViewModel>
    {
        public ReadOnlyPageLogic(ReadOnlyPageViewModel viewModel) : base(viewModel)
        {
        }
    }
}
