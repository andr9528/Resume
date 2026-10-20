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
            [LinkKey.REMARK_LINKEDIN.ToKey()] =
                "Don't mind the weird looking link, LinkedIn doesn't like my apostrophe.",
            [LinkKey.REMARK_PERSONAL_PAGE.ToKey()] = "To view this CV online.",
            [LinkKey.TITLE_PERSONAL_PAGE.ToKey()] = "Personal Webpage",
        };

        private static Dictionary<string, string> Profile { get; } = new()
        {
            [ProfileKey.DESCRIPTION.ToKey()] = Paragraphs(
                "- Experience with C#/.NET and Entity Framework Core, including freelance work for Odense Mobil Rep and a project at Fashionhero.",
                "- Experience with TypeScript and React from my employment at TV 2, developing and maintaining internal software tools.",
                "- Solid understanding of SQL and databases through several years of working with Entity Framework Core.",
                "- Experience with Scrum and collaboration in development teams, primarily from TV 2.",
                "- Use Git for version control and have several publicly available projects on GitHub.",
                "- Focus on code quality, readability, and maintainability, applying DRY and SOLID principles.",
                "- Analytical and solution-oriented, with the ability to quickly learn new technologies and programming languages."),
        };

        private static Dictionary<string, string> Education { get; } = new()
        {
            [EducationKey.DESCRIPTION_BACHELOR.ToKey()] =
                "I performed particularly well in .NET Core, Databases, and Testing.",
            [EducationKey.DESCRIPTION_HTX.ToKey()] = "Was part of a small class on the Technology and Design line.",
            [EducationKey.DESCRIPTION_SOFTWARE.ToKey()] =
                "Learned to read and create various UML diagrams as part of training in Scrum-based software development.",
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
            [EmploymentKey.EMPLOYER_FLOWPOINT_DEFENCE.ToKey()] = "Flowpoint Defence A/S",
            [EmploymentKey.EMPLOYER_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()] = "Noergaard Mikkelsen",
            [EmploymentKey.EMPLOYER_TV2.ToKey()] = "Tv2 Danmark",
            [EmploymentKey.JOB_TITLE_APPS4ALL.ToKey()] = "Mobile Developer",
            [EmploymentKey.JOB_TITLE_FASHIONHERO_INTERNSHIP.ToKey()] = "Software Developer",
            [EmploymentKey.JOB_TITLE_FLOWPOINT_DEFENCE.ToKey()] = "Software Developer",
            [EmploymentKey.JOB_TITLE_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()] = "Software Developer",
            [EmploymentKey.JOB_TITLE_TV2.ToKey()] = "Software Developer",
            [EmploymentKey.WORK_DESCRIPTION_APPS4ALL.ToKey()] = Paragraphs(
                "My primary task was to develop new mobile applications suitable to Android, for using in Point-of-Sale units.",
                "Development of the mobile applications I did through the use of Xamarin Forms.",
                "In addition to this, I also developed some Microservices to support the mobile applications.",
                "The microservices were deployed to Google Cloud."),
            [EmploymentKey.WORK_DESCRIPTION_FASHIONHERO_INTERNSHIP.ToKey()] = Paragraphs(
                "Developed a C# solution to convert XML inventory data into a new format for use in a sales portal. The solution used a local SQLite database with Entity Framework Core as an intermediary.",
                "", "The project is publicly available on GitHub:"),
            [EmploymentKey.WORK_DESCRIPTION_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()] = Paragraphs(
                "Using C# and Uno Platform as the frontend framework, I developed a program to register prompts for AI's.",
                "These Prompts were then able to be executed on registered AI's, starting with ChatGPT.",
                "Afterwards the AI's response would be saved, for use to generate statistics with.", "",
                "The aim of the program was to collect quantitative data on how AI's respond to the same Prompts, before Noergaard Mikkelsen starts to apply changes to their customers websites, in an attempt to influence AI's responses.",
                "The program is open source, and a version of it can be found on my GitHub profile, through the link below."),

            [EmploymentKey.WORK_DESCRIPTION_TV2.ToKey()] = Paragraphs(
                "As part of a Scrum team, I worked on developing and maintaining internal software tools supporting TV 2's sports and news coverage. " +
                "I primarily worked with TypeScript and React, including further development and modernization of existing solutions.",
                "",
                "On the CasparCG ClipTool project, I rewrote the frontend to improve the project structure and limit components to one per file, making the code easier to navigate and maintain. " +
                "I also improved the backend's handling of settings between sessions, fixed several bugs, and introduced the ability to hide selected files in the GUI.",
                "",
                "On the Sofie project, I worked on backend functionality involving MongoDB integration and the frontend-facing presentation layer. " +
                "I also helped migrate company-specific code from the old repository to the new structure.", "",
                "During my employment, I gained experience with collaboration and planning tools such as Jira, Confluence, and Lucidchart. " +
                "I also went from having no prior experience with TypeScript to becoming almost as comfortable with it as I am with C#."),
            [EmploymentKey.WORK_DESCRIPTION_FLOWPOINT_DEFENCE.ToKey()] = Paragraphs(
                "Due to an NDA, I can only mention that I contributed to the development of C# software used to automate processes for the navy."),
            [EmploymentKey.EMPLOYER_ODENSE_MOBIL_REP.ToKey()] = "Odense Mobil Rep",
            [EmploymentKey.JOB_TITLE_ODENSE_MOBIL_REP.ToKey()] = "Software Developer",
            [EmploymentKey.WORK_DESCRIPTION_ODENSE_MOBIL_REP.ToKey()] = Paragraphs(
                "Developed a complete desktop application for managing mobile phone repairs in approximately 54 hours using C#/.NET 10, Uno Platform, and Entity Framework Core (SQLite).",
                "",
                "Used AI, primarily ChatGPT, for brainstorming, code reviews, and parts of the implementation, while taking responsibility for architecture, technical decisions, integration, testing, and quality assurance.",
                "", "The project is publicly available on GitHub:"),
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
                "",
                "Some of the ideas I have shared with other modders for the game, and I will thus likely collaborate with them if needed.",
                "",
                "The game is developed using Unity, therefore C# is the language to be used, which is an advantage for me. " +
                "It uses Harmony as the access point for modders, which may also be useful for future projects."),
            [ProjectKey.ONI_MODDING_TITLE.ToKey()] = "Oxygen Not Included Modding",
            [ProjectKey.AOM_MODDING_DESCRIPTION.ToKey()] = Paragraphs(
                "In my spare time, I maintain several mods for Age of Mythology: Retold.", "",
                "Since the game’s modding system is data-driven through XML files, I developed a custom tool to streamline updating and maintaining these mods. " +
                "The tool loads game data from XML files and applies transformations based on the desired mod configuration, ensuring consistent and efficient updates.",
                "",
                "In addition, I created a companion tool for managing mods outside the game, allowing enabling and disabling of mods, as well as saving and activating full playsets. " +
                "The tools are built using C#, Uno Platform, and Entity Framework Core, and are actively being expanded with new features."),
            [ProjectKey.AOM_MODDING_TITLE.ToKey()] = "Age of Mythology Retold Modding",
            [ProjectKey.TOWER_DEFENCE_DEV_DESCRIPTION.ToKey()] = Paragraphs(
                "I have a game in mind that I would like to slowly get started on.", "",
                "Currently I have noted down many details of the planned game, but have not started on any code for it yet.",
                "", "The game will be developed using Unity with C#, aligning with my existing experience.", "",
                "The genre will be Tower Defence / Roguelike, with inspiration from a number of mythologies, as a nod to my interest in Age of Mythology."),
            [ProjectKey.TOWER_DEFENCE_DEV_TITLE.ToKey()] = "Roguelike Tower Defence Game",
            [ProjectKey.TRACKER_DESCRIPTION.ToKey()] = Paragraphs(
                "A highly modular program usable to track a number of things, depending on the modules included.", "",
                "It will be developed using C#, Entity Framework Core, and Uno Platform as frontend.", "",
                "Planned modules include: Dining, Budget, and Time."),
            [ProjectKey.TRACKER_TITLE.ToKey()] = "Tracker Application",
        };

        private static Dictionary<string, string> References { get; } = new()
        {
            [ReferencesKey.COMPANY_NAME_NOERGAARD_MIKKELSEN.ToKey()] = "Noergaard Mikkelsen",
            [ReferencesKey.COMPANY_NAME_TV2.ToKey()] = "Tv2 Denmark",
            [ReferencesKey.COMPANY_NAME_SPECIALISTERNE.ToKey()] = "Specialisterne",
        };

        private static Dictionary<string, string> Courses { get; } = new()
        {
            [CourseKey.ORACLE_JAVA_SE_8_PROGRAMMING_NAME.ToKey()] = "Oracle Java SE 8 Programming",
            [CourseKey.ORACLE_JAVA_SE_8_PROGRAMMING_DESCRIPTION.ToKey()] =
                "Course in Java SE 8 development — learned Java syntax and programming fundamentals.",

            [CourseKey.SPECIALISTERNE_ACADEMY_NAME.ToKey()] = "Specialisterne Academy • Kochsgade 31, 5000 Odense C",
            [CourseKey.SPECIALISTERNE_ACADEMY_DESCRIPTION.ToKey()] = Paragraphs(
                "Strengthened my skills in C#, Entity Framework Core, and Uno Platform through several development projects, including REST APIs, a full-stack inventory management system, and smaller applications. Worked both independently and in groups and gained an introduction to COBOL."),
        };

        private static Dictionary<string, string> UserInterface { get; } = new()
        {
            [UserInterfaceKey.SKILLS_HEADER.ToKey()] = "Skills",
            [UserInterfaceKey.EDUCATION_HEADER.ToKey()] = "Education",
            [UserInterfaceKey.EMPLOYMENT_HEADER.ToKey()] = "Employment History",
            [UserInterfaceKey.REFERENCES_HEADER.ToKey()] = "References",
            [UserInterfaceKey.LANGUAGES_HEADER.ToKey()] = "Languages",
            [UserInterfaceKey.PROFILE_HEADER.ToKey()] = "Profile",
            [UserInterfaceKey.PHONE_LABEL.ToKey()] = "Phone",
            [UserInterfaceKey.ADDRESS_LABEL.ToKey()] = "Address",
            [UserInterfaceKey.GENERAL_HEADER.ToKey()] = "General Information",
            [UserInterfaceKey.DATE_OF_BIRTH_LABEL.ToKey()] = "Birthday",
            [UserInterfaceKey.NAME_LABEL.ToKey()] = "Full Name",
            [UserInterfaceKey.THE_LABEL.ToKey()] = "the",
            [UserInterfaceKey.OF_LABEL.ToKey()] = "of",
            [UserInterfaceKey.PROJECTS_HEADER.ToKey()] = "Projects",
            [UserInterfaceKey.COURSES_HEADER.ToKey()] = "Courses",
            [UserInterfaceKey.TOTAL_HOURS_LABEL.ToKey()] = "Hours in total",
        };

        public static Dictionary<string, string> All { get; } = Merge(Links, Profile, Education, Employment,
            GeneralInformation, Languages, Projects, References, UserInterface, Courses);
    }
}
