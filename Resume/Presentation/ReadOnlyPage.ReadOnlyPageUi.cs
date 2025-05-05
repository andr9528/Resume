using Resume.Localization.Abstractions;
using Resume.Presentation.Core;
using Resume.Presentation.Section;
using Resume.Services.Abstractions;

namespace Resume.Presentation;

public partial class ReadOnlyPage
{
    private class ReadOnlyPageUi : BaseUi<ReadOnlyPageLogic, ReadOnlyPageViewModel>
    {
        public ReadOnlyPageUi(
            ReadOnlyPageLogic logic, ReadOnlyPageViewModel viewModel, ILocaleService localeService,
            ILocalizationCategories categories, IEntityService entityService) : base(logic, viewModel, localeService,
            categories, entityService)
        {
        }

        protected override void ConfigureGrid(Grid grid)
        {
            const int columnOneWidth = 60;
            const int columnTwoWidth = 100 - columnOneWidth;

            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.ColumnDefinitions(new GridLength(columnOneWidth, GridUnitType.Star),
                new GridLength(columnTwoWidth, GridUnitType.Star));
            grid.RowDefinitions(GridLength.Auto);
        }

        protected override void AddControlsToGrid(Grid grid)
        {
            EmploymentSection employmentSection = new EmploymentSection(EntityService, LocaleService, LocaleCategories)
                .Grid(row: 0, column: 0);

            grid.Children.Add(employmentSection);
        }

        internal ScrollView CreateScrollView()
        {
            var scrollView = new ScrollView
            {
                HorizontalScrollBarVisibility = ScrollingScrollBarVisibility.Hidden,
                VerticalScrollBarVisibility = ScrollingScrollBarVisibility.Visible,
                Margin = new Thickness(80, 0),
            };

            scrollView.Content(CreateContentGrid());

            return scrollView;
        }
    }
}
