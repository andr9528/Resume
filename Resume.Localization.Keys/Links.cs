using Resume.Localization.Keys.Abstraction;

namespace Resume.Localization.Keys;

public record Links : ILinks
{
    /// <inheritdoc />
    public string FashionHeroGitHubProject => "Link_FashionHeroGitHubProject";

    /// <inheritdoc />
    public string Tv2CliptoolGitHubProject { get; }

    /// <inheritdoc />
    public string Tv2SofieServerGitHubProject { get; }

    /// <inheritdoc />
    public string Tv2SofieAngularGitHubProject { get; }
};
