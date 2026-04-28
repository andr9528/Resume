using Resume.Abstraction.Enums.Keys;
using Resume.Abstraction.Interfaces.Resume;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Extensions;
using Resume.Frontend.Presentation.Core;
using Resume.Frontend.Presentation.Factory;
using Resume.Models.Extensions;

namespace Resume.Frontend.Presentation.Section;

public partial class ReferencesSection
{
    private class ReferencesSectionUi : BaseUi<ReferencesSectionLogic, ReferencesSectionViewModel>
    {
        private readonly ILocaleService localeService;

        /// <inheritdoc />
        public ReferencesSectionUi(
            ReferencesSectionLogic logic, ReferencesSectionViewModel viewModel, IEntityService entityService,
            ILocaleService localeService) : base(logic, viewModel, entityService)
        {
            this.localeService = localeService;
        }

        /// <inheritdoc />
        protected override void ConfigureGrid(Grid grid)
        {
            int visibleReferenceCount = EntityService.GetReferences().Count(reference => reference.IsShown);

            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.RowDefinitions(Enumerable.Repeat(new GridLength(10, GridUnitType.Auto), visibleReferenceCount + 1)
                .ToArray());
        }

        /// <inheritdoc />
        protected override void AddControlsToGrid(Grid grid)
        {
            TextBlock sectionHeader = TextBlockFactory.BuildSectionHeader(
                localeService.GetLocalizedString(UserInterfaceKey.REFERENCES_HEADER.ToKey())).SetRow(0);
            var pieces = EntityService.GetReferences().Where(reference => reference.IsShown)
                .Select((reference, index) => BuildPiece(reference).Grid(row: index + 1, column: 0));

            grid.Children.Add(sectionHeader);
            grid.Children.AddRange(pieces);
        }

        private Border BuildPiece(IReference reference)
        {
            StackPanel panel = StackPanelFactory.CreateDefaultPanel();
            panel.Orientation = Orientation.Vertical;

            panel.Children.Add(BuildPieceHeader(reference));

            StackPanel? contactInformation = BuildContactInformation(reference);

            if (contactInformation != null)
            {
                panel.Children.Add(contactInformation);
            }

            return panel.WrapWithTopBorder();
        }

        private TextBlock BuildPieceHeader(IReference reference)
        {
            return new TextBlock
            {
                Text = $"{reference.Name} - {reference.Company}",
                FontSize = 16,
                Margin = new Thickness(0, 0, 0, 10),
            };
        }

        private StackPanel? BuildContactInformation(IReference reference)
        {
            StackPanel panel = StackPanelFactory.CreateDefaultPanel();
            panel.Orientation = Orientation.Vertical;
            panel.Margin = new Thickness(0, 0, 0, 10);

            var hasItems = false;

            hasItems |= AddContactItem(panel, "Email", reference.Email);
            hasItems |= AddContactItem(panel, GetPhoneTranslation(), reference.Phone);
            hasItems |= AddContactItem(panel, "LinkedIn", reference.LinkedIn);

            return hasItems ? panel : null;
        }

        private bool AddContactItem(StackPanel panel, string label, string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            panel.Children.Add(new TextBlock
            {
                Text = $"- {label}: {value}",
                FontSize = 14,
                Margin = new Thickness(0, 0, 0, 2),
            });

            return true;
        }

        private string GetPhoneTranslation()
        {
            return localeService.GetLocalizedString(UserInterfaceKey.PHONE_LABEL.ToKey());
        }
    }
}
