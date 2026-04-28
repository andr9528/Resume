using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Core;
using Resume.Frontend.Presentation.Section;
using Resume.Frontend.Extensions;
using Resume.Frontend.Presentation.Factory;

namespace Resume.Frontend.Presentation;

public partial class StructureFrame
{
    private class StructureFrameUi : BaseUi<StructureFrameLogic, StructureFrameViewModel>
    {
        private readonly ILocaleService localeService;
        private const int OUTER_MARGIN_COLUMN_WIDTH = 4;
        private const int CONTENT_DIVIDER_COLUMN_WIDTH = 3;
        private const int CONTENT_COLUMN_ONE_WIDTH = 55;
        private const int CONTENT_COLUMN_TWO_WIDTH = 30;

        private readonly int[] gridColumnWidths =
        [
            OUTER_MARGIN_COLUMN_WIDTH, CONTENT_COLUMN_ONE_WIDTH, CONTENT_DIVIDER_COLUMN_WIDTH, CONTENT_COLUMN_TWO_WIDTH,
            OUTER_MARGIN_COLUMN_WIDTH,
        ];

        public StructureFrameUi(
            StructureFrameLogic logic, StructureFrameViewModel viewModel, IEntityService entityService,
            ILocaleService localeService) : base(logic, viewModel, entityService)
        {
            this.localeService = localeService;
        }

        protected override void ConfigureGrid(Grid grid)
        {
            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.ColumnDefinitions(gridColumnWidths.Select(x => new GridLength(x, GridUnitType.Star)).ToArray());
            grid.RowDefinitions(GridLength.Auto);
        }

        protected override void AddControlsToGrid(Grid grid)
        {
            Grid columnOneContent = CreateAndFillColumnOne();
            Grid columnTwoContent = CreateAndFillColumnTwo();

            grid.Children.Add(columnOneContent);
            grid.Children.Add(columnTwoContent);
        }

        private Grid CreateAndFillColumnOne()
        {
            ProfileSection profileSection = new(EntityService, localeService);
            EmploymentSection employmentSection = new(EntityService, localeService);
            EducationSection educationSection = new(EntityService, localeService);
            CoursesSection coursesSection = new(EntityService, localeService);
            ProjectsSection projectsSection = new(EntityService, localeService);

            Border[] sections =
            [
                profileSection,
                employmentSection,
                educationSection,
                coursesSection,
                projectsSection,
            ];

            return CreateAndFillColumn(1, sections);
        }

        private Grid CreateAndFillColumnTwo()
        {
            GeneralSection generalSection = new(EntityService, localeService);
            LinksSection linksSection = new(EntityService, localeService);
            SkillsSection skillsSection = new(EntityService, localeService);
            LanguagesSection languagesSection = new(EntityService, localeService);
            ReferencesSection referencesSection = new(EntityService, localeService);

            Border[] sections =
            [
                generalSection,
                skillsSection,
                linksSection,
                languagesSection,
                referencesSection,
            ];

            return CreateAndFillColumn(3, sections);
        }

        private Grid CreateAndFillColumn(int column, Border[] sections)
        {
            int[] rowDefinitions = Enumerable.Repeat(1, sections.Length).ToArray();

            Grid grid = GridFactory.CreateDefaultGrid().SetColumn(column).SetRow(0)
                .DefineRows(GridUnitType.Auto, rowDefinitions);

            grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            grid.MinWidth = 0;

            foreach ((Border section, int index) in sections.Select((section, index) => (section, index)))
            {
                grid.Children.Add(section.SetRow(index));
            }

            return grid;
        }

        internal ScrollViewer CreateScrollView()
        {
            var scrollView = new ScrollViewer
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Margin = new Thickness(20, 0),
            };

            scrollView.Content(CreateContentGrid());

            return scrollView;
        }
    }
}
