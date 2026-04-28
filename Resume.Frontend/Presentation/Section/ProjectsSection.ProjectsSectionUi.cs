using Resume.Abstraction.Enums.Keys;
using Resume.Abstraction.Interfaces.Resume;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Extensions;
using Resume.Frontend.Presentation.Core;
using Resume.Frontend.Presentation.Factory;
using Resume.Models.Extensions;

namespace Resume.Frontend.Presentation.Section;

public partial class ProjectsSection
{
    private class ProjectsSectionUi : BaseUi<ProjectsSectionLogic, ProjectsSectionViewModel>
    {
        private readonly ILocaleService localeService;

        /// <inheritdoc />
        public ProjectsSectionUi(
            ProjectsSectionLogic logic, ProjectsSectionViewModel viewModel, IEntityService entityService,
            ILocaleService localeService) : base(logic, viewModel, entityService)
        {
            this.localeService = localeService;
        }

        /// <inheritdoc />
        protected override void ConfigureGrid(Grid grid)
        {
            int projectCount = EntityService.GetProjects().Count;

            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.RowDefinitions(Enumerable.Repeat(new GridLength(10, GridUnitType.Auto), projectCount + 1).ToArray());
        }

        /// <inheritdoc />
        protected override void AddControlsToGrid(Grid grid)
        {
            TextBlock sectionHeader = TextBlockFactory.BuildSectionHeader(
                localeService.GetLocalizedString(UserInterfaceKey.PROJECTS_HEADER.ToKey())).SetRow(0);

            var pieces = EntityService.GetProjects()
                .Select((project, index) => BuildPiece(project).Grid(row: index + 1, column: 0));

            grid.Children.Add(sectionHeader);
            grid.Children.AddRange(pieces);
        }

        private Border BuildPiece(IProject project)
        {
            StackPanel panel = StackPanelFactory.CreateDefaultPanel();
            panel.Orientation = Orientation.Vertical;

            panel.Children.Add(BuildProjectName(project));
            panel.Children.Add(BuildProjectDescription(project));

            ListView? links = ListViewFactory.BuildLinksListView(project.Links);

            if (links is not null)
            {
                panel.Children.Add(links);
            }

            return panel.WrapWithTopBorder();
        }

        private TextBlock BuildProjectName(IProject project)
        {
            return new TextBlock
            {
                Text = project.Name,
                FontSize = 18,
                Margin = new Thickness(0, 0, 0, 6),
                VerticalAlignment = VerticalAlignment.Top,
            };
        }

        private TextBlock BuildProjectDescription(IProject project)
        {
            return new TextBlock
            {
                Text = project.Description,
                FontSize = 14,
                Margin = new Thickness(0, 0, 0, 5),
                VerticalAlignment = VerticalAlignment.Top,
                TextWrapping = TextWrapping.WrapWholeWords,
            };
        }
    }
}
