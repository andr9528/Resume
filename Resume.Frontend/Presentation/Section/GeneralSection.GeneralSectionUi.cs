using System.Globalization;
using Resume.Abstraction.Enums;
using Resume.Abstraction.Enums.Keys;
using Resume.Abstraction.Interfaces.Resume;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Extensions;
using Resume.Frontend.Presentation.Core;
using Resume.Frontend.Presentation.Factory;
using Resume.Models.Extensions;

namespace Resume.Frontend.Presentation.Section;

public partial class GeneralSection
{
    private class GeneralSectionUi : BaseUi<GeneralSectionLogic, GeneralSectionViewModel>
    {
        private readonly ILocaleService localeService;

        /// <inheritdoc />
        public GeneralSectionUi(
            GeneralSectionLogic logic,
            GeneralSectionViewModel viewModel,
            IEntityService entityService,
            ILocaleService localeService) : base(logic, viewModel, entityService)
        {
            this.localeService = localeService;
        }

        /// <inheritdoc />
        protected override void ConfigureGrid(Grid grid)
        {
            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.RowDefinitions(Enumerable.Repeat(new GridLength(10, GridUnitType.Auto), 6).ToArray());
        }

        /// <inheritdoc />
        protected override void AddControlsToGrid(Grid grid)
        {
            IGeneralInformation generalInformation = EntityService.GetGeneralInformation();

            var sectionHeader = TextBlockFactory.BuildSectionHeader(
                localeService.GetLocalizedString(UserInterfaceKey.GENERAL_HEADER.ToKey())).SetRow(0);

            List<Grid> pieces =
            [
                BuildPiece(UserInterfaceKey.NAME_LABEL, BuildFullName(generalInformation)),
                BuildPiece(UserInterfaceKey.DATE_OF_BIRTH_LABEL, BuildDateOfBirth(generalInformation.DateOfBirth), false),
                BuildPiece(UserInterfaceKey.EMAIL_LABEL, generalInformation.Email),
                BuildPiece(UserInterfaceKey.PHONE_LABEL, BuildPhoneNumber(generalInformation)),
                BuildPiece(UserInterfaceKey.ADDRESS_LABEL, BuildAddress(generalInformation)),
            ];

            grid.Children.Add(sectionHeader);

            foreach ((Grid piece, int index) in pieces.Select((piece, index) => (piece, index)))
            {
                grid.Children.Add(piece.Grid(row: index + 1, column: 0));
            }
        }

        private string BuildPhoneNumber(IGeneralInformation generalInformation)
        {
            string number = generalInformation.PhoneNumber.ToString();

            var segments = Enumerable.Range(0, number.Length / 2).Select(i => number.Substring(i * 2, 2));

            string formattedNumber = string.Join(" ", segments);

            if (localeService.IsTargetedLanguage(LanguageType.ENGLISH))
            {
                return $"{generalInformation.AreaCode} {formattedNumber}";
            }

            return formattedNumber;
        }

        private string BuildDateOfBirth(DateTime date)
        {
            CultureInfo culture = localeService.GetCurrentCulture();

            string dayName = Capitalize(date.ToString("dddd", culture));
            string monthName = date.ToString("MMMM", culture);
            string the = localeService.GetLocalizedString(UserInterfaceKey.THE_LABEL.ToKey());
            string of = localeService.GetLocalizedString(UserInterfaceKey.OF_LABEL.ToKey());
            string daySuffix = localeService.IsTargetedLanguage(LanguageType.ENGLISH) ? $"rd {of}" : of;

            return $"{dayName} {the} {date.Day}{daySuffix} {monthName} {date.Year}";
        }

        private string Capitalize(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            return char.ToUpper(value[0]) + value[1..];
        }

        private string BuildAddress(IGeneralInformation generalInformation)
        {
            return string.Join(", ", new[]
            {
                generalInformation.Address,
                generalInformation.City,
                generalInformation.PostalCode.ToString(),
                generalInformation.Country,
            }.Where(value => !string.IsNullOrWhiteSpace(value)));
        }

        private Grid BuildPiece(UserInterfaceKey labelKey, string value, bool isValueCopyable = true)
        {
            var grid = GridFactory.CreateDefaultGrid()
                .DefineColumns(GridUnitType.Star, 2, 3);

            grid.MinHeight = 60;

            grid.Children.Add(BuildLabel(labelKey).Grid(row: 0, column: 0));
            grid.Children.Add(BuildValue(value, isValueCopyable).Grid(row: 0, column: 1));

            return grid;
        }

        private TextBlock BuildLabel(UserInterfaceKey labelKey)
        {
            return new TextBlock
            {
                Text = $"{localeService.GetLocalizedString(labelKey.ToKey())}:",
                FontSize = 16,
                Margin = new Thickness(10, 0, 0, 5),
                VerticalAlignment = VerticalAlignment.Center,
            };
        }

        private TextBox BuildValue(string value, bool copyable = true)
        {
            var textBox = new TextBox
            {
                Text = value,
                FontSize = 16,
                Margin = new Thickness(0),

                IsReadOnly = true,
                BorderThickness = new Thickness(0),
                Background = new SolidColorBrush(Colors.Transparent),

                Padding = new Thickness(0),
                MinHeight = 0,
                Height = double.NaN,
                VerticalAlignment = VerticalAlignment.Top,

                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = false,
            };

            if (copyable)
            {
                textBox.Tapped += (_, _) => Logic.CopyToClipboard(value);
            }

            return textBox;
        }

        private string BuildFullName(IGeneralInformation generalInformation)
        {
            return string.Join(" ", new[]
            {
                generalInformation.FirstName,
                generalInformation.MiddleName,
                generalInformation.LastName,
            }.Where(value => !string.IsNullOrWhiteSpace(value)));
        }
    }
}
