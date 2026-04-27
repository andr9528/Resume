using Resume.Abstraction.Enums;
using Resume.Abstraction.Enums.Keys;
using Resume.Abstraction.Interfaces.Resume;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Extensions;
using Resume.Frontend.Presentation.Core;
using Resume.Frontend.Presentation.Factory;
using Resume.Models.Extensions;

namespace Resume.Frontend.Presentation.Section;

public partial class LanguagesSection
{
    private class LanguagesSectionUi : BaseUi<LanguagesSectionLogic, LanguagesSectionViewModel>
    {
        private readonly ILocaleService localeService;

        /// <inheritdoc />
        public LanguagesSectionUi(
            LanguagesSectionLogic logic, LanguagesSectionViewModel viewModel, IEntityService entityService,
            ILocaleService localeService) : base(
            logic, viewModel, entityService)
        {
            this.localeService = localeService;
        }

        /// <inheritdoc />
        protected override void ConfigureGrid(Grid grid)
        {
            int languageCount = EntityService.GetLanguages().Count;

            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.RowDefinitions(Enumerable.Repeat(new GridLength(10, GridUnitType.Auto), languageCount + 1).ToArray());
        }

        /// <inheritdoc />
        protected override void AddControlsToGrid(Grid grid)
        {
            var sectionHeader = TextBlockFactory.BuildSectionHeader(
                localeService.GetLocalizedString(UserInterfaceKey.LANGUAGES_HEADER.ToKey())).SetRow(0);

            var pieces = EntityService.GetLanguages()
                .Select((language, index) => BuildPiece(language).Grid(row: index + 1, column: 0));

            grid.Children.Add(sectionHeader);
            grid.Children.AddRange(pieces);
        }

        private Grid BuildPiece(ILanguage language)
        {
            var grid = GridFactory.CreateDefaultGrid().DefineColumns(GridUnitType.Star, 3, 2);

            grid.Children.Add(BuildLanguageName(language).Grid(row: 0, column: 0));
            grid.Children.Add(BuildLevel(language).Grid(row: 0, column: 1));

            return grid;
        }

        private TextBlock BuildLanguageName(ILanguage language)
        {
            return new TextBlock
            {
                Text = language.Name,
                FontSize = 18,
                Margin = new Thickness(10, 0, 0, 5),
                VerticalAlignment = VerticalAlignment.Center,
            };
        }

        private TextBlock BuildLevel(ILanguage language)
        {
            return new TextBlock
            {
                Text = BuildStars(language.Level),
                FontSize = 18,
                Margin = new Thickness(0, 0, 0, 5),
                VerticalAlignment = VerticalAlignment.Center,
            };
        }

        private string BuildStars(LanguageLevel level)
        {
            const int maxLevel = 5;

            int value = Math.Clamp((int)level, 0, maxLevel);
            int remaining = maxLevel - value;

            return string.Concat(Enumerable.Repeat("★", value))
                   + string.Concat(Enumerable.Repeat("☆", remaining));
        }
    }
}
