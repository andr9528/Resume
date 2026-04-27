using Resume.Abstraction.Enums.Keys;
using Resume.Models.Extensions;

namespace Resume.Services;

public static partial class Translations
{
    public static class Fallback
    {
        private static Dictionary<string, string> Links { get; } = new()
        {
            [LinkKey.FASHION_HERO_GITHUB_PROJECT.ToKey()] = "https://github.com/FashionHeroOnGit/PortalProject",
            [LinkKey.NOERGAARD_MIKKELSEN_GITHUB_PROJECT.ToKey()] = "https://github.com/andr9528/gaio",
            [LinkKey.TRACKER_GITHUB_PROJECT.ToKey()] = "https://github.com/andr9528/Tracker",
            [LinkKey.RETOLD_MODS_GITHUB_PROJECT.ToKey()] = "https://github.com/andr9528/Retold-Mods",
            [LinkKey.RETOLD_DEV_TOOL_PROJECT.ToKey()] = "https://github.com/andr9528/AoMR-Mod-Development-Tools",
            [LinkKey.RETOLD_MOD_MANAGER_GITHUB_PROJECT.ToKey()] = "https://github.com/andr9528/AoMR-Mod-Manager",
            [LinkKey.PROTECT_THE_TEMPLE_GITHUB_PROJECT.ToKey()] = "https://github.com/andr9528/ProtectTheTemple.Public",
            [LinkKey.PERSONAL_GITHUB.ToKey()] = "https://github.com/andr9528",
            [LinkKey.PERSONAL_LINKEDIN.ToKey()] = "https://www.linkedin.com/in/andr%C3%A9-steenhoff-madsen-65a22698/",
            [LinkKey.PERSONAL_PAGE.ToKey()] = "https://andr9528.github.io/",
            [LinkKey.TV2_CLIPTOOL_GITHUB_PROJECT.ToKey()] = "https://github.com/tv2/casparcg-cliptool",
            [LinkKey.TITLE_GITHUB.ToKey()] = "GitHub",
            [LinkKey.TITLE_LINKEDIN.ToKey()] = "LinkedIn",
        };

        private static Dictionary<string, string> Profile { get; } = new()
        {
            [ProfileKey.NAME.ToKey()] = "André Steenhoff Madsen",
        };
        
        private static Dictionary<string, string> UserInterface { get; } = new()
        {
            [UserInterfaceKey.EMAIL_LABEL.ToKey()] = "Email",
            [UserInterfaceKey.LINKS_HEADER.ToKey()] = "Links",
            [UserInterfaceKey.TITLE.ToKey()] = "Resume",
        };

        public static Dictionary<string, string> All { get; } = Merge(Links, Profile, UserInterface);

    }
}
