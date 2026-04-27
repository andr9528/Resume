using Resume.Abstraction.Enums.Keys;
using Resume.Models.Extensions;

namespace Resume.Services;

public static partial class Translations
{
    public static class Danish
    {
        private static Dictionary<string, string> Links { get; } = new()
        {
            [LinkKey.REMARK_GITHUB.ToKey()] = "Tag et kig på min tidligere kode.",
            [LinkKey.REMARK_LINKEDIN.ToKey()] =
                "Tag dig ikke af at linket ser lidt underligt ud, LinkedIn kan ikke lide min apostrof.",
            [LinkKey.REMARK_PERSONAL_PAGE.ToKey()] = "Til at se dette CV online.",
            [LinkKey.TITLE_PERSONAL_PAGE.ToKey()] = "Personlig hjemmeside",
        };

        private static Dictionary<string, string> Profile { get; } = new()
        {
            [ProfileKey.DESCRIPTION.ToKey()] = Paragraphs(
                "- Analytisk, løsningsorienteret og kvalitetsbevidst udvikler med Bachelor i Softwareudvikling.", "",
                "- Erfaren i C#/.NET, TypeScript og React.", "Erfaring med arbejde efter SCRUM under softwareudvikling.",
                "- Fokuserer på DRY og SOLID principper under udvikling.", "",
                "- Har anvendt Entity Framework Core i flere år, og har i den forbindelse fået god forståelse for SQL.",
                "- Gør brug af Git til udviklingsopgaver, og har alt tidligere kode på GitHub.", "",
                "- Finder Cloud, Azure og Microservice Architecture interessant.",
                "- Har nemt ved at forstå ukendte kodesprog, og lærer derved hurtigt nye sprog.")
        };

        private static Dictionary<string, string> Education { get; } = new()
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

        private static Dictionary<string, string> Employment { get; } = new()
        {
            [EmploymentKey.EMPLOYMENT_TYPE_CONTRACT.ToKey()] = "Kontrakt",
            [EmploymentKey.EMPLOYMENT_TYPE_INTERNSHIP.ToKey()] = "Praktik",
            [EmploymentKey.EMPLOYMENT_TYPE_PERMANENT.ToKey()] = "Fastansat",
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
                "Udviklingen af mobil applikationer gjorde jeg gennem Xamarin Forms.", "",
                "Dertil udviklede jeg også nogle Microservices til at understøtte mobil applikationerne.",
                "Microservicerne blev sat i funktion via Google Cloud."),
            [EmploymentKey.WORK_DESCRIPTION_FASHIONHERO_INTERNSHIP.ToKey()] = Paragraphs(
                "Ved brug af C#, arbejdet jeg på at udvikle et program der kunne loade deres lagerdata, fra den eksporterede Xml fil, ind i en lokal database.",
                "Det indlæste lager ville derefter kunne blive eksporteret til en Xml fil i et andet format, til brug for at få en anden side til at sælge vores produkter for os.", "",
                "Under dette arbejde gjorde jeg brug af Entity Framework Core til at skrive til den Sqlite database."),
            [EmploymentKey.WORK_DESCRIPTION_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()] = Paragraphs(
                "Ved brug af C# og Uno Platform som frontend framework, udviklede jeg et program til at registrere Prompts til AI's.",
                "Disse prompts kunne så blive sendt til registrerede AI's, med udgangspunkt i OpenAI's ChatGPT, hvorefter deres svar bliver gemt til statistik.", "",
                "Programmets mål var at indsamle kvantitativ data på hvordan AI's svarer på den samme prompt, før Nørgård Mikkelsen forsøger at påvirke deres svar.",
                "Projektet er Open Source, og kan findes på min GitHub profil."),
            [EmploymentKey.WORK_DESCRIPTION_TV2.ToKey()] = Paragraphs(
                "Jeg deltog i et team af udviklere hvor vi ved brug af SCRUM udviklede interne værktøjer, hvor nogle er Open Source.",
                "Siden min kontrakt udløb er nogle projekter blevet Closed Source.", "",
                "På Cliptool projektet genskrev jeg frontend for at begrænse komponenter til én per fil.",
                "Omskrivningen forbedrede også projektets struktur markant.",
                "Jeg forbedrede også backend håndtering af settings mellem sessioner.",
                "Jeg rettede flere fejl og introducerede muligheden for at skjule filer i GUI.", "",
                "På Sofie projektet arbejdede jeg med backend og Mongo integration samt frontend præsentationslag.",
                "Jeg hjalp også med migrering af virksomhedsspecifikt kode til ny struktur.", "",
                "Jeg gik fra ingen TypeScript erfaring til at være næsten lige så komfortabel som i C#."),
        };

        private static Dictionary<string, string> GeneralInformation { get; } = new()
        {
            [GeneralInformationKey.COUNTRY.ToKey()] = "Danmark",
        };

        private static Dictionary<string, string> Languages { get; } = new()
        {
            [LanguageKey.DANISH_LANGUAGE.ToKey()] = "Dansk",
            [LanguageKey.ENGLISH_LANGUAGE.ToKey()] = "Engelsk",
            [LanguageKey.GERMAN_LANGUAGE.ToKey()] = "Tysk",
        };

        private static Dictionary<string, string> Projects { get; } = new()
        {
            [ProjectKey.ONI_MODDING_DESCRIPTION.ToKey()] = Paragraphs(
                "Jeg har nogle idéer til mods til et af mine yndlingsspil for tiden, Oxygen Not Included, som jeg muligvis vil bruge tid på at realisere.",
                "",
                "Nogle af idéerne har jeg delt med andre moddere, og jeg vil derfor sandsynligvis samarbejde med dem efter behov.",
                "",
                "Spillet er udviklet i Unity, og derfor er C# det anvendte sprog, hvilket er en fordel for mig. " +
                "Det benytter Harmony som adgangspunkt for moddere, hvilket også kan være nyttigt i fremtidige projekter."),
            [ProjectKey.ONI_MODDING_TITLE.ToKey()] = "Oxygen Not Included Modding",
            [ProjectKey.AOM_MODDING_DESCRIPTION.ToKey()] = Paragraphs(
                "I min fritid vedligeholder jeg flere mods til Age of Mythology: Retold.", "",
                "Da spillets modding-system er datadrevet gennem XML-filer, har jeg udviklet et værktøj til at effektivisere opdatering og vedligeholdelse af disse mods. " +
                "Værktøjet indlæser spildata fra XML-filer og transformerer dataene baseret på den ønskede mod-konfiguration, hvilket sikrer konsistente og effektive opdateringer.",
                "",
                "Derudover har jeg udviklet et værktøj til at håndtere mods uden for spillet, som gør det muligt at aktivere/deaktivere mods samt gemme og indlæse komplette playsets. " +
                "Værktøjerne er udviklet i C#, Uno Platform og Entity Framework Core og bliver løbende udvidet med nye funktioner."),
            [ProjectKey.AOM_MODDING_TITLE.ToKey()] = "Age of Mythology Retold Modding",
            [ProjectKey.TOWER_DEFENCE_DEV_DESCRIPTION.ToKey()] = Paragraphs(
                "Jeg har en spilidé, som jeg gerne vil begynde at arbejde på over tid.", "",
                "Jeg har allerede noteret mange detaljer om det planlagte spil, men har endnu ikke påbegyndt selve udviklingen.",
                "", "Spillet vil blive udviklet i Unity med C#, hvilket passer godt til min eksisterende erfaring.", "",
                "Genren vil være Tower Defence / Roguelike, med inspiration fra forskellige mytologier som et nik til min interesse for Age of Mythology."),
            [ProjectKey.TOWER_DEFENCE_DEV_TITLE.ToKey()] = "Roguelike Tårn Forsvars Spil",
            [ProjectKey.TRACKER_DESCRIPTION.ToKey()] = Paragraphs(
                "Et modulært program, der kan bruges til at holde styr på forskellige ting, afhængigt af hvilke moduler der er inkluderet.",
                "", "Vil blive udviklet i C#, med Entity Framework Core og Uno Platform som frontend.", "",
                "Planlagte moduler inkluderer: Mad, Budget og Tid."),
            [ProjectKey.TRACKER_TITLE.ToKey()] = "Sporings Applikation",
        };

        private static Dictionary<string, string> References { get; } = new()
        {
            [ReferencesKey.COMPANY_NAME_NOERGAARD_MIKKELSEN.ToKey()] = "Nørgård Mikkelsen",
            [ReferencesKey.COMPANY_NAME_TV2.ToKey()] = "Tv2 Danmark",
            [ReferencesKey.COMPANY_NAME_SPECIALISTERNE.ToKey()] = "Specialisterne",
        };

        private static Dictionary<string, string> Courses { get; } = new()
        {
            [CourseKey.ORACLE_JAVA_SE_8_PROGRAMMING_NAME.ToKey()] = "Oracle Java SE 8 Programmering",
            [CourseKey.ORACLE_JAVA_SE_8_PROGRAMMING_DESCRIPTION.ToKey()] =
                "Kursus i udvikling med Java, mere specifikt Java SE 8. Under kurset lærte jeg blandt andet syntaksen for Java kode.",

            [CourseKey.SPECIALISTERNE_ACADEMY_NAME.ToKey()] = "Specialisterne Academy • Kochsgade 31, 5000 Odense C",
            [CourseKey.SPECIALISTERNE_ACADEMY_DESCRIPTION.ToKey()] = Paragraphs(
                "Styrket min erfaring med C#, Entity Framework Core og Uno Platform under små projekter. Projekterne inkluderede følgende:",
                "- Et Wordle spil.", "- Et program til download af hovedsageligt PDF-filer, med hastighed som fokus.",
                "- Oprettelse af API til eksisterende database data.",
                "- Et fullstack lagerstyringssystem som gruppeopgave.", "",
                "Den afsluttende del af kurset inkluderede muligheden for en række selvvalgte projekter, hvoriblandt jeg valgte at løse en række opgaver fokuseret på at lære COBOL.")
        };

        private static Dictionary<string, string> UserInterface { get; } = new()
        {
            [UserInterfaceKey.SKILLS_HEADER.ToKey()] = "Færdigheder",
            [UserInterfaceKey.EDUCATION_HEADER.ToKey()] = "Uddannelse",
            [UserInterfaceKey.EMPLOYMENT_HEADER.ToKey()] = "Ansættelseshistorik",
            [UserInterfaceKey.REFERENCES_HEADER.ToKey()] = "Referencer",
            [UserInterfaceKey.LANGUAGES_HEADER.ToKey()] = "Sprog",
            [UserInterfaceKey.PROFILE_HEADER.ToKey()] = "Profil",
            [UserInterfaceKey.PHONE_LABEL.ToKey()] = "Telefon",
            [UserInterfaceKey.ADDRESS_LABEL.ToKey()] = "Addresse",
            [UserInterfaceKey.GENERAL_HEADER.ToKey()] = "Generel Information",
            [UserInterfaceKey.PROJECTS_HEADER.ToKey()] = "Projekter",
            [UserInterfaceKey.DATE_OF_BIRTH_LABEL.ToKey()] = "Fødselsdag",
            [UserInterfaceKey.NAME_LABEL.ToKey()] = "Fulde Navn",
            [UserInterfaceKey.THE_LABEL.ToKey()] = "den",
            [UserInterfaceKey.OF_LABEL.ToKey()] = ".",
            [UserInterfaceKey.COURSES_HEADER.ToKey()] = "Kursuser",
        };

        public static Dictionary<string, string> All { get; } = Merge(Links, Profile, Education, Employment,
            GeneralInformation, Languages, Projects, References, UserInterface, Courses);

    }
}
