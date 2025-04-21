using Resume.Localization.Abstractions;
using Resume.Localization.Strings;

namespace Resume.Localization.Keys;

public record LinkKeys : ILinkKeys
{
    /// <inheritdoc />
    public string FashionHeroGitHubProject { get; init; } = nameof(Resources.Link_Fashion_Hero_GitHub_Project);

    /// <inheritdoc />
    public string Tv2CliptoolGitHubProject { get; init; } = nameof(Resources.Link_Tv2_Cliptool_GitHub_Project);

    /// <inheritdoc />
    public string Tv2SofieServerGitHubProject { get; init; } = nameof(Resources.Link_Tv2_Sofie_Server_GitHub_Project);

    /// <inheritdoc />
    public string Tv2SofieAngularGitHubProject { get; init; } = nameof(Resources.Link_Tv2_Sofie_Angular_GitHub_Project);

    /// <inheritdoc />
    public string RemarkGitHub { get; init; } = nameof(Resources.Link_Remark_GitHub);

    /// <inheritdoc />
    public string RemarkLinkedIn { get; init; } = nameof(Resources.Link_Remark_LinkedIn);

    /// <inheritdoc />
    public string RemarkPersonalPage { get; init; } = nameof(Resources.Link_Remark_Personal_Page);

    /// <inheritdoc />
    public string TitleGitHub { get; init; } = nameof(Resources.Link_Title_GitHub);

    /// <inheritdoc />
    public string TitleLinkedIn { get; init; } = nameof(Resources.Link_Title_LinkedIn);

    /// <inheritdoc />
    public string TitlePersonalPage { get; init; } = nameof(Resources.Link_Title_Personal_Page);

    /// <inheritdoc />
    public string PersonalGithub { get; init; } = nameof(Resources.Link_Personal_Github);

    /// <inheritdoc />
    public string NoergaardMikkelsenGitHubProject { get; init; } =
        nameof(Resources.Link_Noergaard_Mikkelsen_GitHub_Project);

    /// <inheritdoc />
    public string PersonalLinkedIn { get; init; } = nameof(Resources.Link_Personal_LinkedIn);

    /// <inheritdoc />
    public string PersonalPage { get; init; } = nameof(Resources.Link_Personal_Page);
}
