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
            OUTER_MARGIN_COLUMN_WIDTH, CONTENT_COLUMN_ONE_WIDTH, CONTENT_DIVIDER_COLUMN_WIDTH, CONTENT_COLUMN_TWO_WIDTH, OUTER_MARGIN_COLUMN_WIDTH,
        ];

        public StructureFrameUi(StructureFrameLogic logic, StructureFrameViewModel viewModel, IEntityService entityService,
            ILocaleService localeService) : base(logic,
            viewModel, entityService)
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
            var columnOneContent = CreateAndFillColumnOne();
            var columnTwoContent = CreateAndFillColumnTwo();

            grid.Children.Add(columnOneContent);
            grid.Children.Add(columnTwoContent);
        }

        private Grid CreateAndFillColumnOne()
        {
            var columnOne = GridFactory.CreateDefaultGrid().SetColumn(1).SetRow(0)
                .DefineRows(GridUnitType.Auto, 1, 1, 1, 1, 1);
            columnOne.HorizontalAlignment = HorizontalAlignment.Stretch;
            columnOne.MinWidth = 0;

            EmploymentSection employmentSection = new EmploymentSection(EntityService, localeService).SetRow(0);
            EducationSection educationSection = new EducationSection(EntityService, localeService).SetRow(1);
            CoursesSection coursesSection = new CoursesSection(EntityService, localeService).SetRow(2);
            ProjectsSection projectsSection = new ProjectsSection(EntityService, localeService).SetRow(3);
            ReferencesSection referencesSection = new ReferencesSection(EntityService, localeService).SetRow(4);

            columnOne.Add(employmentSection);
            columnOne.Add(educationSection);
            columnOne.Add(coursesSection);
            columnOne.Add(projectsSection);
            columnOne.Add(referencesSection);

            return columnOne;
        }

        private Grid CreateAndFillColumnTwo()
        {
            var columnTwo = GridFactory.CreateDefaultGrid().SetColumn(3).SetRow(0)
                .DefineRows(GridUnitType.Auto, 1, 1, 1, 1);
            columnTwo.HorizontalAlignment = HorizontalAlignment.Stretch;
            columnTwo.MinWidth = 0;

            GeneralSection generalSection = new GeneralSection(EntityService, localeService).SetRow(0);
            SkillsSection skillsSection = new SkillsSection(EntityService, localeService).SetRow(1);
            LinksSection linksSection = new LinksSection(EntityService, localeService).SetRow(2);
            LanguagesSection languagesSection = new LanguagesSection(EntityService, localeService).SetRow(3);

            columnTwo.Add(generalSection);
            columnTwo.Add(linksSection);
            columnTwo.Add(skillsSection);
            columnTwo.Add(languagesSection);

            return columnTwo;
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
