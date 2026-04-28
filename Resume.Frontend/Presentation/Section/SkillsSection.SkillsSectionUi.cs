using Resume.Abstraction.Enums;
using Resume.Abstraction.Enums.Keys;
using Resume.Abstraction.Interfaces.Resume;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Extensions;
using Resume.Frontend.Presentation.Core;
using Resume.Frontend.Presentation.Factory;
using Resume.Models.Extensions;

namespace Resume.Frontend.Presentation.Section;

public partial class SkillsSection
{
    private class SkillsSectionUi : BaseUi<SkillsSectionLogic, SkillsSectionViewModel>
    {
        private readonly ILocaleService localeService;

        /// <inheritdoc />
        public SkillsSectionUi(
            SkillsSectionLogic logic, SkillsSectionViewModel viewModel, IEntityService entityService,
            ILocaleService localeService) : base(logic, viewModel, entityService)
        {
            this.localeService = localeService;
        }

        /// <inheritdoc />
        protected override void ConfigureGrid(Grid grid)
        {
            int skillCount = EntityService.GetSkills().Count;

            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.RowDefinitions(Enumerable.Repeat(new GridLength(10, GridUnitType.Auto), skillCount + 1).ToArray());
        }

        /// <inheritdoc />
        protected override void AddControlsToGrid(Grid grid)
        {
            TextBlock sectionHeader = TextBlockFactory.BuildSectionHeader(
                localeService.GetLocalizedString(UserInterfaceKey.SKILLS_HEADER.ToKey())).SetRow(0);

            var pieces = EntityService.GetSkills()
                .Select((skill, index) => BuildPiece(skill).Grid(row: index + 1, column: 0));

            grid.Children.Add(sectionHeader);
            grid.Children.AddRange(pieces);
        }

        private Grid BuildPiece(ISkill skill)
        {
            Grid grid = GridFactory.CreateDefaultGrid().DefineColumns(GridUnitType.Star, 3, 2);

            TextBlock skillName = BuildSkillName(skill);
            TextBlock expertise = BuildExpertise(skill);

            grid.Children.Add(skillName.Grid(row: 0, column: 0));
            grid.Children.Add(expertise.Grid(row: 0, column: 1));

            return grid;
        }

        private TextBlock BuildSkillName(ISkill skill)
        {
            return new TextBlock
            {
                Text = skill.Name,
                FontSize = 18,
                Margin = new Thickness(10, 0, 0, 5),
                VerticalAlignment = VerticalAlignment.Center,
            };
        }

        private TextBlock BuildExpertise(ISkill skill)
        {
            return new TextBlock
            {
                Text = BuildStars(skill.Expertise),
                FontSize = 18,
                Margin = new Thickness(0, 0, 0, 5),
                VerticalAlignment = VerticalAlignment.Center,
            };
        }

        private string BuildStars(SkillLevel expertise)
        {
            const int maxExpertise = 5;

            int value = Math.Clamp((int) expertise, 0, maxExpertise);
            int remaining = maxExpertise - value;

            return string.Concat(Enumerable.Repeat("★", value)) + string.Concat(Enumerable.Repeat("☆", remaining));
        }
    }
}
