using Resume.Localization.Abstractions;

namespace Resume.Localization.Keys;

public record LinkKeys : ILinkKeys
{
    /// <inheritdoc />
    public string FashionHeroGitHubProject { get; init; } = "Link_FashionHeroGitHubProject";

    /// <inheritdoc />
    public string Tv2CliptoolGitHubProject { get; init; } = "Link_Tv2CliptoolGitHubProject";

    /// <inheritdoc />
    public string Tv2SofieServerGitHubProject { get; init; } = "Link_Tv2SofieServerGitHubProject";

    /// <inheritdoc />
    public string Tv2SofieAngularGitHubProject { get; init; } = "Link_Tv2SofieAngularGitHubProject";
};
