using System.Collections.Generic;
using System.Text;
using Resume.Abstraction.Enums.Keys;
using Resume.Models.Extensions;

namespace Resume.Services;

public static class Translations
{
    public static Dictionary<string, string> Fallback { get; } = new()
    {
        [LinkKey.FASHION_HERO_GITHUB_PROJECT.ToKey()] = "https://github.com/FashionHeroOnGit/PortalProject",
        [LinkKey.NOERGAARD_MIKKELSEN_GITHUB_PROJECT.ToKey()] = "https://github.com/andr9528/gaio",
        [LinkKey.PERSONAL_GITHUB.ToKey()] = "https://github.com/andr9528",
        [LinkKey.PERSONAL_LINKEDIN.ToKey()] = "https://www.linkedin.com/in/andr%C3%A9-steenhoff-madsen-65a22698/",
        [LinkKey.PERSONAL_PAGE.ToKey()] = "https://andr9528.github.io/",
        [LinkKey.TV2_CLIPTOOL_GITHUB_PROJECT.ToKey()] = "https://github.com/tv2/casparcg-cliptool",
        [ProfileKey.NAME.ToKey()] = "André Steenhoff Madsen",
        [LinkKey.TITLE_GITHUB.ToKey()] = "GitHub",
        [LinkKey.TITLE_LINKEDIN.ToKey()] = "LinkedIn",
    };

    public static Dictionary<string, string> English { get; } = new()
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
            "This position was a one month Company Internship.",
            "Using C#, I worked on developing a program to load their storage, exported to an Xml file, into a local database.",
            "The loaded storage would then be export to a Xml in another format, for use by other sites to sell products from us.",
            "During this work I made use of Entity Framework Core to write to a Sqlite database."),
        [EmploymentKey.WORK_DESCRIPTION_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()] = Paragraphs(
            "This position was a one month Company Internship.",
            "Using C# and Uno Platform as the frontend framework, I developed a program to register prompts for AI's.",
            "These Prompts were then able to be executed on registered AI's, starting with ChatGPT.",
            "Afterwards the AI's response would be saved, for use to generate statistics with.",
            "The aim of the program was to collect quantitative data on how AI's respond to the same Prompts, before Noergaard Mikkelsen starts to apply changes to their customers websites, in an attempt to influence AI's responses.",
            "The program is open source, and a version of it can be found on my GitHub profile, through the link below."),
        [EmploymentKey.WORK_DESCRIPTION_TV2.ToKey()] = Paragraphs(
            "This position ended due to a contract running out, and it not being able to be renewed, not because I was fired.",
            "I was part of a team of developers who by use of SCRUM, developed on a number of internal tools, some of which are Open Source projects.",
            "Some of the projects I have contributed to have since my contract ran out been changed to be Closed Source. I do know that this change is only temporary.",
            "On the Cliptool project, I rewrote the frontend side of the application, mainly to limit the amount of components per file to one.",
            "The rewrite was also done to apply a better file structure to the project, as it was difficult to know where different components were located beforehand.",
            "I also rewrote parts of the backend of Cliptool in the process, mainly to save changes to settings for between sessions better than before.",
            "During this rewrite, I managed to fix a number of smaller bugs, and introduce the ability to hide selected files from the GUI.",
            "On the Sofie project, I helped with creating parts of the backend, related to interacting with the underlying Mongo database and the frontend-facing presentation layer.",
            "I also helped with moving over parts of the company-specific code from the old repository, to the new structure.",
            "All in all, I went from never having touched or used TypeScript, to now feeling just as comfortable in that as I am in C#."),
        [GeneralInformationKey.COUNTRY.ToKey()] = "Denmark",
        [LanguageKey.DANISH_LANGUAGE.ToKey()] = "Danish",
        [LanguageKey.ENGLISH_LANGUAGE.ToKey()] = "English",
        [LanguageKey.GERMAN_LANGUAGE.ToKey()] = "German",
        [LinkKey.REMARK_GITHUB.ToKey()] = "Take a peek at my previous code.",
        [LinkKey.REMARK_LINKEDIN.ToKey()] = "Don't mind the weird looking link, LinkedIn doesn't like my apostrophe.",
        [LinkKey.REMARK_PERSONAL_PAGE.ToKey()] = "To view this CV online.",

        [LinkKey.TITLE_PERSONAL_PAGE.ToKey()] = "Personal Webpage",
        [ProfileKey.DESCRIPTION.ToKey()] = Paragraphs(
            "I am an easy-to-learn, logically thinking developer with experience in C# / .Net. During my most recent position at Tv2 Danmark, I also gained experience with TypeScript / React.",
            "As a background, I have a Computer Science degree and on top of that a Bachelor in Software Development. This education, along with my sense of logic, allows me to understand other coding languages to some degree, even if I have no previous experience with them.",
            "When I develop I strive to adhere to the DRY and SOLID principles as much as possible. With these principles in focus, I feel that code gets a good quality."),
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
        [ReferencesKey.COMPANY_NAME_NOERGAARD_MIKKELSEN.ToKey()] = "Noergaard Mikkelsen",
        [ReferencesKey.COMPANY_NAME_TV2.ToKey()] = "Tv2 Denmark",
        [UserInterfaceKey.SKILLS_HEADER.ToKey()] = "Skills",
        [UserInterfaceKey.TITLE.ToKey()] = "Resume",
    };

    public static Dictionary<string, string> Danish { get; } = new()
    {
        [EducationKey.DESCRIPTION_BACHELOR.ToKey()] =
            "Fag jeg præsterede specielt godt i inkluderer .Net Core, Database og Test.",
        [EducationKey.DESCRIPTION_HTX.ToKey()] = "Var del af en lille klasse på Teknologi og Design linjen.",
        [EducationKey.DESCRIPTION_SOFTWARE.ToKey()] =
            "Lærte at læse og skabe en længere række UML modeller i forbindelse med at blive oplært i udvikling ved brug af SCRUM.",
        [EducationKey.GRADE_BACHELOR.ToKey()] = "Professionsbachelor i Software Udvikling",
        [EducationKey.GRADE_HTX.ToKey()] = "Højere Teknisk Eksamen",
        [EducationKey.GRADE_SOFTWARE.ToKey()] = "Datamatiker",
        [EducationKey.SCHOOL_NAME_HTX.ToKey()] = "Svendborg Erhvervsskole",
        [EducationKey.SCHOOL_NAME_UCL.ToKey()] = "University College Lillebælt",
        [EmploymentKey.EMPLOYER_APPS4ALL.ToKey()] = "Apps4All",
        [EmploymentKey.EMPLOYER_FASHIONHERO_INTERNSHIP.ToKey()] = "Fashionhero",
        [EmploymentKey.EMPLOYER_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()] = "Nørgård Mikkelsen",
        [EmploymentKey.EMPLOYER_TV2.ToKey()] = "Tv2 Danmark",
        [EmploymentKey.JOB_TITLE_APPS4ALL.ToKey()] = "Mobil Udvikler",
        [EmploymentKey.JOB_TITLE_FASHIONHERO_INTERNSHIP.ToKey()] = "Software Udvikler",
        [EmploymentKey.JOB_TITLE_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()] = "Software Udvikler",
        [EmploymentKey.JOB_TITLE_TV2.ToKey()] = "Software Udvikler",
        [EmploymentKey.WORK_DESCRIPTION_APPS4ALL.ToKey()] = Paragraphs(
            "Min primære arbejdsopgave var at udvikle nye mobil applikationer egnet til Android, til brug på Point-of-Sale enheder.",
            "Udviklingen af mobil applikationer gjorde jeg gennem Xamarin Forms.",
            "Dertil udviklede jeg også nogle Microservices til at understøtte mobil applikationerne.",
            "Microservicerne blev sat i funktion via Google Cloud."),
        [EmploymentKey.WORK_DESCRIPTION_FASHIONHERO_INTERNSHIP.ToKey()] = Paragraphs(
            "Denne stilling var en, en-måneds virksomhedspraktik.",
            "Ved brug af C#, arbejdet jeg på at udvikle et program der kunne loade deres lagerdata, fra den eksporterede Xml fil, ind i en lokal database.",
            "Det indlæste lager ville derefter kunne blive eksporteret til en Xml fil i et andet format, til brug for at få en anden side til at sælge vores produkter for os.",
            "Under dette arbejde gjorde jeg brug af Entity Framework Core til at skrive til den Sqlite database."),
        [EmploymentKey.WORK_DESCRIPTION_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()] = Paragraphs(
            "Denne stilling var en, en-måneds virksomhedspraktik.",
            "Ved brug af C# og Uno Platform som frontend framework, udviklede jeg et program til at registrere Prompts til AI's.",
            "Disse prompts kunne så blive sendt til registrerede AI's, med udgangspunkt i OpenAI's ChatGPT, hvorefter deres svar bliver gemt til statistik.",
            "Programmets mål var at indsamle kvantitativ data på hvordan AI's svarer på den samme prompt, før Nørgård Mikkelsen forsøger at påvirke deres svar.",
            "Projektet er Open Source, og kan findes på min GitHub profil."),
        [EmploymentKey.WORK_DESCRIPTION_TV2.ToKey()] = Paragraphs(
            "Denne stilling sluttede på grund af min kontrakt udløb, og ikke kunne blive fornyet, ikke fordi jeg blev fyret.",
            "Jeg deltog i et team af udviklere hvor vi ved brug af SCRUM udviklede interne værktøjer, hvor nogle er Open Source.",
            "Siden min kontrakt udløb er nogle projekter blevet Closed Source, dog kun midlertidigt.",
            "På Cliptool projektet genskrev jeg frontend for at begrænse komponenter til én per fil.",
            "Omskrivningen forbedrede også projektets struktur markant.",
            "Jeg forbedrede også backend håndtering af settings mellem sessioner.",
            "Jeg rettede flere fejl og introducerede muligheden for at skjule filer i GUI.",
            "På Sofie projektet arbejdede jeg med backend og Mongo integration samt frontend præsentationslag.",
            "Jeg hjalp også med migrering af virksomhedsspecifikt kode til ny struktur.",
            "Jeg gik fra ingen TypeScript erfaring til at være lige så komfortabel som i C#."),
        [GeneralInformationKey.COUNTRY.ToKey()] = "Danmark",
        [LanguageKey.DANISH_LANGUAGE.ToKey()] = "Dansk",
        [LanguageKey.ENGLISH_LANGUAGE.ToKey()] = "Engelsk",
        [LanguageKey.GERMAN_LANGUAGE.ToKey()] = "Tysk",
        [LinkKey.REMARK_GITHUB.ToKey()] = "Tag et kig på min tidligere kode.",
        [LinkKey.REMARK_LINKEDIN.ToKey()] =
            "Tag dig ikke af at linket ser lidt underligt ud, LinkedIn kan ikke lide min apostrof.",
        [LinkKey.REMARK_PERSONAL_PAGE.ToKey()] = "Til at se dette CV online.",
        [LinkKey.TITLE_PERSONAL_PAGE.ToKey()] = "Personlig hjemmeside",
        [LinkKey.TV2_CLIPTOOL_GITHUB_PROJECT.ToKey()] = "",
        [ProfileKey.DESCRIPTION.ToKey()] = Paragraphs(
            "Jeg er en lærenem logisk tænkende udvikler, med erfaring i C# / .Net. Jeg har også under min seneste stilling ved Tv2 Danmark fået erfaring med TypeScript / React.",
            "Som baggrund har jeg en Datamatiker og oven på den en Bachelor i Softwareudvikling.",
            "Denne uddannelse sammen med min logiske sans gør at jeg kan forstå andre kodesprog i nogen grad.",
            "Når jeg udvikler stræber jeg efter at følge DRY og SOLID principperne."),
        [ProjectKey.ONI_MODDING_DESCRIPTION.ToKey()] = Paragraphs(
            "Jeg har ideer til mods til Oxygen Not Included som jeg gerne vil udvikle.",
            "Jeg har delt ideer med andre modders og kan sparre med dem.", "Spillet er udviklet i Unity og bruger C#.",
            "Modding sker via Harmony som jeg gerne vil lære."),
        [ProjectKey.ONI_MODDING_TITLE.ToKey()] = "Oxygen Not Included Modding",
        [ProjectKey.TOWER_DEFENCE_DEV_DESCRIPTION.ToKey()] = Paragraphs(
            "Jeg har et spil i tankerne jeg gerne vil begynde på.", "Jeg har mange noter men ingen kode endnu.",
            "Jeg overvejer Godot som engine pga C# og Unity kontroversen.",
            "Genren bliver Tower Defence / Roguelike inspireret af mytologier."),
        [ProjectKey.TOWER_DEFENCE_DEV_TITLE.ToKey()] = "Roguelike Tårn Forsvars Spil",
        [ProjectKey.TRACKER_DESCRIPTION.ToKey()] = Paragraphs("Et modulært program til at tracke forskellige ting.",
            "Udvikles i C#, Entity Framework Core og Uno Platform.", "Planlagte moduler: mad, budget og tid."),
        [ProjectKey.TRACKER_TITLE.ToKey()] = "Sporings Applikation",
        [ReferencesKey.COMPANY_NAME_NOERGAARD_MIKKELSEN.ToKey()] = "Nørgård Mikkelsen",
        [ReferencesKey.COMPANY_NAME_TV2.ToKey()] = "Tv2 Danmark",
        [UserInterfaceKey.SKILLS_HEADER.ToKey()] = "Evner",
        [UserInterfaceKey.TITLE.ToKey()] = "Resume",
    };

    private static string Paragraphs(params string[] paragraphs)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < paragraphs.Length; i++)
        {
            if (i > 0)
            {
                sb.AppendLine();
                sb.AppendLine();
            }

            sb.Append(paragraphs[i].Trim());
        }

        return sb.ToString();
    }
}
