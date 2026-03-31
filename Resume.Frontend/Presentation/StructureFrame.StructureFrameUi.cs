using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Core;
using Resume.Frontend.Presentation.Section;

namespace Resume.Frontend.Presentation;

public partial class StructureFrame
{
    private class StructureFrameUi : BaseUi<StructureFrameLogic, StructureFrameViewModel>
    {
        public StructureFrameUi(StructureFrameLogic logic, StructureFrameViewModel viewModel, IEntityService entityService) : base(logic,
            viewModel, entityService)
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
            EmploymentSection employmentSection = new EmploymentSection(EntityService).Grid(row: 0, column: 0);

            grid.Children.Add(employmentSection);
        }

        internal ScrollViewer CreateScrollView()
        {
            var scrollView = new ScrollViewer
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Margin = new Thickness(80, 0),
            };

            scrollView.Content(CreateContentGrid());

            return scrollView;
        }
    }
}
