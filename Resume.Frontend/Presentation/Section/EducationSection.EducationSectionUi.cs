using Resume.Abstraction.Interfaces.Resume;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Core;
using Resume.Frontend.Presentation.Factory;

namespace Resume.Frontend.Presentation.Section;

public partial class EducationSection
{
    private class EducationSectionUi : BaseUi<EducationSectionLogic, EducationSectionViewModel>
    {
        /// <inheritdoc />
        public EducationSectionUi(
            EducationSectionLogic logic, EducationSectionViewModel viewModel, IEntityService entityService) : base(
            logic, viewModel, entityService)
        {
        }

        /// <inheritdoc />
        protected override void ConfigureGrid(Grid grid)
        {
            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.RowDefinitions(Enumerable
                .Repeat(new GridLength(10, GridUnitType.Auto), EntityService.GetEducations().Count).ToArray());
        }

        /// <inheritdoc />
        protected override void AddControlsToGrid(Grid grid)
        {
            var pieces = EntityService.GetEducations()
                .Select((education, index) => BuildPiece(education).Grid(row: index, column: 0));

            grid.Children.AddRange(pieces);
        }

        private StackPanel BuildPiece(IEducation education)
        {
            StackPanel panel = StackPanelFactory.CreateDefaultPanel();
            panel.Orientation = Orientation.Vertical;

            TextBlock pieceHeader = BuildPieceHeader(education);
            TextBlock pieceSubHeader = BuildPieceSubHeader(education);
            TextBlock pieceDescription = BuildPieceDescription(education);

            panel.Children.Add(pieceHeader);
            panel.Children.Add(pieceSubHeader);
            panel.Children.Add(pieceDescription);

            return panel;
        }

        private TextBlock BuildPieceHeader(IEducation education)
        {
            return new TextBlock
            {
                Text = $"{education.SchoolName} - {education.Grade}",
                FontSize = 16,
                Margin = new Thickness(0, 0, 0, 10),
            };
        }

        private TextBlock BuildPieceSubHeader(IEducation education)
        {
            string end = education.EndDate != null ? $"{education.EndDate:MMM yyyy}" : "TEMP";

            return new TextBlock
            {
                Text = $"{education.City}, {education.StartDate:MMM yyyy} - {end}",
                FontSize = 14,
                Margin = new Thickness(0, 0, 0, 10),
            };
        }

        private TextBlock BuildPieceDescription(IEducation education)
        {
            return new TextBlock
            {
                Text = education.Description,
                FontSize = 14,
                Margin = new Thickness(0, 0, 0, 10),
                TextWrapping = TextWrapping.WrapWholeWords,
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };
        }
    }
}
