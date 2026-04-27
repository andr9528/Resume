using Resume.Abstraction.Enums.Keys;
using Resume.Models.Extensions;

namespace Resume.Services;

public static partial class Translations
{
    public static class English
    {
        private static Dictionary<string, string> Links { get; } = new()
        {
            [LinkKey.REMARK_GITHUB.ToKey()] = "Take a peek at my previous code.",
            [LinkKey.REMARK_LINKEDIN.ToKey()] = "Don't mind the weird looking link, LinkedIn doesn't like my apostrophe.",
            [LinkKey.REMARK_PERSONAL_PAGE.ToKey()] = "To view this CV online.",
            [LinkKey.TITLE_PERSONAL_PAGE.ToKey()] = "Personal Webpage",
        };

        private static Dictionary<string, string> Profile { get; } = new()
        {
            [ProfileKey.DESCRIPTION.ToKey()] = Paragraphs(
                "I am an easy-to-learn, logically thinking developer with experience in C# / .Net. During my most recent position at Tv2 Danmark, I also gained experience with TypeScript / React.",
                "As a background, I have a Computer Science degree and on top of that a Bachelor in Software Development. This education, along with my sense of logic, allows me to understand other coding languages to some degree, even if I have no previous experience with them.",
                "When I develop I strive to adhere to the DRY and SOLID principles as much as possible. With these principles in focus, I feel that code gets a good quality."),
        };

        private static Dictionary<string, string> Education { get; } = new()
        {
            [EducationKey.DESCRIPTION_BACHELOR.ToKey()] =
                "Subjects I performed well in includes .Net Core, Database and Test.",
            [EducationKey.DESCRIPTION_HTX.ToKey()] = "Was part of a small class on the Technology and Design line.",
            [EducationKey.DESCRIPTION_SOFTWARE.ToKey()] =
                "Learned about reading and creating a number of UML diagrams, in connection with learning to develop using SCRUM.",
            [EducationKey.GRADE_BACHELOR.ToKey()] = "Bachelor in Software Development",
            [EducationKey.GRADE_HTX.ToKey()] = "Higher Technical Exam",
            [EducationKey.GRADE_SOFTWARE.ToKey()] = "Computer Science",
            [EducationKey.SCHOOL_NAME_HTX.ToKey()] = "Svendborg Erhversskole",
            [EducationKey.SCHOOL_NAME_UCL.ToKey()] = "University College Lillebaelt",
        };

        private static Dictionary<string, string> Employment { get; } = new()
        {
            [EmploymentKey.EMPLOYMENT_TYPE_CONTRACT.ToKey()] = "Contract",
            [EmploymentKey.EMPLOYMENT_TYPE_INTERNSHIP.ToKey()] = "Internship",
            [EmploymentKey.EMPLOYMENT_TYPE_PERMANENT.ToKey()] = "Permanent Employment",
            [EmploymentKey.EMPLOYER_APPS4ALL.ToKey()] = "Apps4All",
            [EmploymentKey.EMPLOYER_FASHIONHERO_INTERNSHIP.ToKey()] = "Fashionhero",
            [EmploymentKey.EMPLOYER_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()] = "Noergaard Mikkelsen",
            [EmploymentKey.EMPLOYER_TV2.ToKey()] = "Tv2 Danmark",
            [EmploymentKey.JOB_TITLE_APPS4ALL.ToKey()] = "Mobile Developer",
            [EmploymentKey.JOB_TITLE_FASHIONHERO_INTERNSHIP.ToKey()] = "Software Developer",
            [EmploymentKey.JOB_TITLE_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()] = "Software Developer",
            [EmploymentKey.JOB_TITLE_TV2.ToKey()] = "Software Developer",
            [EmploymentKey.WORK_DESCRIPTION_APPS4ALL.ToKey()] = Paragraphs(
                "My primary task was to develop new mobile applications suitable to Android, for using in Point-of-Sale units.",
                "Development of the mobile applications I did through the use of Xamarin Forms.",
                "In addition to this, I also developed some Microservices to support the mobile applications.",
                "The microservices were deployed to Google Cloud."),
            [EmploymentKey.WORK_DESCRIPTION_FASHIONHERO_INTERNSHIP.ToKey()] = Paragraphs(
                "Using C#, I worked on developing a program to load their storage, exported to an Xml file, into a local database.",
                "The loaded storage would then be export to a Xml in another format, for use by other sites to sell products from us.", "",
                "During this work I made use of Entity Framework Core to write to a Sqlite database."),
            [EmploymentKey.WORK_DESCRIPTION_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()] = Paragraphs(
                "Using C# and Uno Platform as the frontend framework, I developed a program to register prompts for AI's.",
                "These Prompts were then able to be executed on registered AI's, starting with ChatGPT.",
                "Afterwards the AI's response would be saved, for use to generate statistics with.", "",
                "The aim of the program was to collect quantitative data on how AI's respond to the same Prompts, before Noergaard Mikkelsen starts to apply changes to their customers websites, in an attempt to influence AI's responses.",
                "The program is open source, and a version of it can be found on my GitHub profile, through the link below."),
            [EmploymentKey.WORK_DESCRIPTION_TV2.ToKey()] = Paragraphs(
                "I was part of a team of developers who by use of SCRUM, developed on a number of internal tools, some of which are Open Source projects.",
                "Some of the projects I have contributed to have since my contract ran out been changed to be Closed Source.", "",
                "On the Cliptool project, I rewrote the frontend side of the application, mainly to limit the amount of components per file to one.",
                "The rewrite was also done to apply a better file structure to the project, as it was difficult to know where different components were located beforehand.",
                "I also rewrote parts of the backend of Cliptool in the process, mainly to save changes to settings for between sessions better than before.",
                "During this rewrite, I managed to fix a number of smaller bugs, and introduce the ability to hide selected files from the GUI.", "",
                "On the Sofie project, I helped with creating parts of the backend, related to interacting with the underlying Mongo database and the frontend-facing presentation layer.",
                "I also helped with moving over parts of the company-specific code from the old repository, to the new structure.", "",
                "All in all, I went from never having touched or used TypeScript, to now feeling almost as comfortable in that as I am in C#."),
        };

        private static Dictionary<string, string> GeneralInformation { get; } = new()
        {
            [GeneralInformationKey.COUNTRY.ToKey()] = "Denmark",
        };

        private static Dictionary<string, string> Languages { get; } = new()
        {
            [LanguageKey.DANISH_LANGUAGE.ToKey()] = "Danish",
            [LanguageKey.ENGLISH_LANGUAGE.ToKey()] = "English",
            [LanguageKey.GERMAN_LANGUAGE.ToKey()] = "German",
        };

        private static Dictionary<string, string> Projects { get; } = new()
        {
            [ProjectKey.ONI_MODDING_DESCRIPTION.ToKey()] = Paragraphs(
                "I have some ideas for mods for one of my favorite games as of late, Oxygen Not Included, which I might spend some time on bringing to life.",
                "Some of the ideas I have shared with other modders for the game, and I will thus likely spar with them if needed.",
                "The game is developed using Unity, therefore C# is the language to be used, which is an advantage for me.",
                "It uses 'Harmony' as the access point for modders, which might help me learn it for use in my own game, if Godot allows it."),
            [ProjectKey.ONI_MODDING_TITLE.ToKey()] = "Oxygen Not Included Modding",
            [ProjectKey.TOWER_DEFENCE_DEV_DESCRIPTION.ToKey()] = Paragraphs(
                "I have a game in mind that I would like to slowly get started on.",
                "Currently I have noted down many details of the planned game, but have not started on any code for it yet.",
                "I am heavily leaning toward using Godot as the game engine of choice, mainly for the C# language, but also due to the controversy about Unity during 2023.",
                "The game genre will be Tower Defence / Roguelike, with inspiration from a number of Mythologies, as a nod to my liking of 'Age of Mythology'."),
            [ProjectKey.TOWER_DEFENCE_DEV_TITLE.ToKey()] = "Roguelike Tower Defence Game",
            [ProjectKey.TRACKER_DESCRIPTION.ToKey()] = Paragraphs(
                "A highly modular program usable to track a number of things, depending on the modules included.",
                "Will be developed using C#, Entity Framework Core and Uno Platform as frontend.",
                "Planned modules include: Dining, Budget and Time."),
            [ProjectKey.TRACKER_TITLE.ToKey()] = "Tracker Application",
        };

        private static Dictionary<string, string> References { get; } = new()
        {
            [ReferencesKey.COMPANY_NAME_NOERGAARD_MIKKELSEN.ToKey()] = "Noergaard Mikkelsen",
            [ReferencesKey.COMPANY_NAME_TV2.ToKey()] = "Tv2 Denmark",
            [ReferencesKey.COMPANY_NAME_SPECIALISTERNE.ToKey()] = "Specialisterne",
        };

        private static Dictionary<string, string> UserInterface { get; } = new()
        {
            [UserInterfaceKey.SKILLS_HEADER.ToKey()] = "Skills",
            [UserInterfaceKey.EDUCATION_HEADER.ToKey()] = "Education",
            [UserInterfaceKey.EMPLOYMENT_HEADER.ToKey()] = "Employment History",
            [UserInterfaceKey.REFERENCES_HEADER.ToKey()] = "References",
            [UserInterfaceKey.LANGUAGES_HEADER.ToKey()] = "Languages",
            [UserInterfaceKey.PROFILE_HEADER.ToKey()] = "Profile",
            [UserInterfaceKey.PHONE.ToKey()] = "Phone",
        };

        public static Dictionary<string, string> All { get; } = Merge(Links, Profile, Education, Employment,
            GeneralInformation, Languages, Projects, References, UserInterface);

    }
}
