using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation.Section;

public partial class ProfileSection
{
    private class ProfileSectionLogic : BaseLogic<ProfileSectionViewModel>
    {
        public ProfileSectionLogic(ProfileSectionViewModel viewModel) : base(viewModel)
        {
        }
    }
}
