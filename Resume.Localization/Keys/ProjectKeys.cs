using Resume.Localization.Abstractions;
using Resume.Localization.Strings;

namespace Resume.Localization.Keys;

public record ProjectKeys : IProjectKeys
{
    /// <inheritdoc />
    public string TrackerTitle { get; init; } = nameof(Resources.Project_Tracker_Title);

    /// <inheritdoc />
    public string TrackerDescription { get; init; } = nameof(Resources.Project_Tracker_Description);

    /// <inheritdoc />
    public string TowerDefenceDevTitle { get; init; } = nameof(Resources.Project_Tower_Defence_Dev_Title);

    /// <inheritdoc />
    public string TowerDefenceDevDescription { get; init; } = nameof(Resources.Project_Tower_Defence_Dev_Description);

    /// <inheritdoc />
    public string OniModdingTitle { get; init; } = nameof(Resources.Project_Oni_Modding_Title);

    /// <inheritdoc />
    public string OniModdingDescription { get; init; } = nameof(Resources.Project_Oni_Modding_Description);
}
