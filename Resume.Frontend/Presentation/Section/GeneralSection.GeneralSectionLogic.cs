using Resume.Frontend.Presentation.Core;
using Windows.ApplicationModel.DataTransfer;

namespace Resume.Frontend.Presentation.Section;

public partial class GeneralSection
{
    private class GeneralSectionLogic : BaseLogic<GeneralSectionViewModel>
    {
        public GeneralSectionLogic(GeneralSectionViewModel viewModel) : base(viewModel)
        {
        }

        public void CopyToClipboard(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            var dataPackage = new DataPackage();
            dataPackage.SetText(value);

            Clipboard.SetContent(dataPackage);
        }
    }
}
