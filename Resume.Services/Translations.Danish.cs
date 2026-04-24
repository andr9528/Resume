using Resume.Abstraction.Enums.Keys;
using Resume.Models.Extensions;

namespace Resume.Services;

public static partial class Translations
{
    public static class Danish
    {
        public static Dictionary<string, string> All { get; } = Merge(
            Links,
            Profile,
            Education,
            Employment,
            GeneralInformation,
            Languages,
            Projects,
            References,
            UserInterface);

        public static Dictionary<string, string> Links { get; } = new()
        {
            [LinkKey.REMARK_GITHUB.ToKey()] = "Tag et kig på min tidligere kode.",
            [LinkKey.REMARK_LINKEDIN.ToKey()] =
                "Tag dig ikke af at linket ser lidt underligt ud, LinkedIn kan ikke lide min apostrof.",
            [LinkKey.REMARK_PERSONAL_PAGE.ToKey()] = "Til at se dette CV online.",
            [LinkKey.TITLE_PERSONAL_PAGE.ToKey()] = "Personlig hjemmeside",
            [LinkKey.TV2_CLIPTOOL_GITHUB_PROJECT.ToKey()] = "",
        };

        public static Dictionary<string, string> Profile { get; } = new()
        {
            [ProfileKey.DESCRIPTION.ToKey()] = Paragraphs(
                "Jeg er en lærenem logisk tænkende udvikler, med erfaring i C# / .Net. Jeg har også under min seneste stilling ved Tv2 Danmark fået erfaring med TypeScript / React.",
                "Som baggrund har jeg en Datamatiker og oven på den en Bachelor i Softwareudvikling.",
                "Denne uddannelse sammen med min logiske sans gør at jeg kan forstå andre kodesprog i nogen grad.",
                "Når jeg udvikler stræber jeg efter at følge DRY og SOLID principperne."),
        };

        public static Dictionary<string, string> Education { get; } = new()
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
        };

        public static Dictionary<string, string> Employment { get; } = new()
        {
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
        };

        public static Dictionary<string, string> GeneralInformation { get; } = new()
        {
            [GeneralInformationKey.COUNTRY.ToKey()] = "Danmark",
        };

        public static Dictionary<string, string> Languages { get; } = new()
        {
            [LanguageKey.DANISH_LANGUAGE.ToKey()] = "Dansk",
            [LanguageKey.ENGLISH_LANGUAGE.ToKey()] = "Engelsk",
            [LanguageKey.GERMAN_LANGUAGE.ToKey()] = "Tysk",
        };

        public static Dictionary<string, string> Projects { get; } = new()
        {
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
        };

        public static Dictionary<string, string> References { get; } = new()
        {
            [ReferencesKey.COMPANY_NAME_NOERGAARD_MIKKELSEN.ToKey()] = "Nørgård Mikkelsen",
            [ReferencesKey.COMPANY_NAME_TV2.ToKey()] = "Tv2 Danmark",
            [ReferencesKey.COMPANY_NAME_SPECIALISTERNE.ToKey()] = "Specialisterne",
        };

        public static Dictionary<string, string> UserInterface { get; } = new()
        {
            [UserInterfaceKey.SKILLS_HEADER.ToKey()] = "Evner",
            [UserInterfaceKey.TITLE.ToKey()] = "Resume",
        };

    }
}
