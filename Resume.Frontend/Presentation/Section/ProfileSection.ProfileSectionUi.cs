using Resume.Abstraction.Enums.Keys;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Extensions;
using Resume.Frontend.Presentation.Core;
using Resume.Frontend.Presentation.Factory;
using Resume.Models.Extensions;

namespace Resume.Frontend.Presentation.Section;

public partial class ProfileSection
{
    private class ProfileSectionUi : BaseUi<ProfileSectionLogic, ProfileSectionViewModel>
    {
        private readonly ILocaleService localeService;

        public ProfileSectionUi(
            ProfileSectionLogic logic, ProfileSectionViewModel viewModel, IEntityService entityService,
            ILocaleService localeService) : base(logic, viewModel, entityService)
        {
            this.localeService = localeService;
        }

        protected override void ConfigureGrid(Grid grid)
        {
            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.RowDefinitions(new GridLength(10, GridUnitType.Auto), new GridLength(10, GridUnitType.Auto));
        }

        protected override void AddControlsToGrid(Grid grid)
        {
            TextBlock sectionHeader = TextBlockFactory.BuildSectionHeader(
                localeService.GetLocalizedString(UserInterfaceKey.PROFILE_HEADER.ToKey())).SetRow(0);

            TextBlock profileText = BuildProfileText().Grid(row: 1, column: 0);

            grid.Children.Add(sectionHeader);
            grid.Children.Add(profileText);
        }

        private TextBlock BuildProfileText()
        {
            return new TextBlock
            {
                Text = EntityService.GetGeneralInformation().ProfileDescription,
                FontSize = 14,
                Margin = new Thickness(0, 0, 0, 10),
                TextWrapping = TextWrapping.WrapWholeWords,
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };
        }
    }
}
