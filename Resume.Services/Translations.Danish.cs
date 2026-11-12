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
                "Jeg er en analytisk og kvalitetsbevidst softwareudvikler, der arbejder struktureret med at finde løsninger på tekniske udfordringer. " +
                "Jeg lægger vægt på at forstå de problemstillinger, jeg arbejder med, og finde gennemtænkte løsninger, der ikke blot fungerer her og nu, men også holder på længere sigt. " +
                "Jeg lærer hurtigt nye teknologier og trives med både at udvikle nye løsninger og forbedre eksisterende systemer.",
                "",
                "Jeg arbejder godt både selvstændigt og i teams, hvor jeg bidrager med overblik, grundighed og en konstruktiv tilgang til samarbejdet. " +
                "Det motiverer mig særligt at udvikle software, hvor jeg kan se, at mit arbejde skaber konkret værdi for brugerne.",
                "",
                "Ud over disse personlige egenskaber har jeg praktisk erfaring med en række teknologier, værktøjer og udviklingsmetoder:",
                "",
                "- Erfaring med C#/.NET og Entity Framework Core, blandt andet fra freelanceprojektet hos Odense Mobil Rep og arbejdet hos Fashionhero.",
                "- Erfaring med TypeScript og React fra min ansættelse hos TV 2, hvor jeg arbejdede med udvikling og vedligeholdelse af interne værktøjer.",
                "- God forståelse for SQL og databaser gennem flere års anvendelse af Entity Framework Core.",
                "- Erfaring med Scrum og samarbejde i udviklingsteams, hovedsageligt fra TV 2.",
                "- Anvender Git til versionsstyring og har flere offentligt tilgængelige projekter på GitHub.",
                "- Fokus på kodekvalitet, læsbarhed og vedligeholdbarhed med anvendelse af DRY- og SOLID-principperne."),
        };

        private static Dictionary<string, string> Education { get; } = new()
        {
            [EducationKey.DESCRIPTION_BACHELOR.ToKey()] =
                "Jeg klarede mig særligt godt i fagene .NET Core, Databaser og Test.",
            [EducationKey.DESCRIPTION_HTX.ToKey()] = "Var del af en lille klasse på Teknologi og Design linjen.",
            [EducationKey.DESCRIPTION_SOFTWARE.ToKey()] =
                "Lærte at læse og skabe en længere række UML-modeller i forbindelse med at blive oplært i udvikling ved brug af Scrum.",
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
            [EmploymentKey.EMPLOYER_FLOWPOINT_DEFENCE.ToKey()] = "Flowpoint Defence A/S",
            [EmploymentKey.EMPLOYER_APPS4ALL.ToKey()] = "Apps4All",
            [EmploymentKey.EMPLOYER_FASHIONHERO_INTERNSHIP.ToKey()] = "Fashionhero",
            [EmploymentKey.EMPLOYER_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()] = "Nørgård Mikkelsen",
            [EmploymentKey.EMPLOYER_TV2.ToKey()] = "Tv2 Danmark",
            [EmploymentKey.JOB_TITLE_APPS4ALL.ToKey()] = "Mobil Udvikler",
            [EmploymentKey.JOB_TITLE_FASHIONHERO_INTERNSHIP.ToKey()] = "Software Udvikler",
            [EmploymentKey.JOB_TITLE_FLOWPOINT_DEFENCE.ToKey()] = "Software Udvikler",
            [EmploymentKey.JOB_TITLE_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()] = "Software Udvikler",
            [EmploymentKey.JOB_TITLE_TV2.ToKey()] = "Software Udvikler",
            [EmploymentKey.WORK_DESCRIPTION_APPS4ALL.ToKey()] = Paragraphs(
                "Min primære arbejdsopgave var at udvikle nye mobil applikationer egnet til Android, til brug på Point-of-Sale enheder.",
                "Udviklingen af mobil applikationer gjorde jeg gennem Xamarin Forms.", "",
                "Dertil udviklede jeg også nogle Microservices til at understøtte mobil applikationerne.",
                "Microservicerne blev sat i funktion via Google Cloud."),
            [EmploymentKey.WORK_DESCRIPTION_FASHIONHERO_INTERNSHIP.ToKey()] = Paragraphs(
                "Udviklede i C# en løsning til at konvertere XML-lagerdata til et nyt format til brug i en salgsportal. Løsningen anvendte en lokal SQLite-database med Entity Framework Core som mellemled.",
                "", "Projektet er offentligt tilgængeligt på GitHub:"),
            [EmploymentKey.WORK_DESCRIPTION_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()] = Paragraphs(
                "Ved brug af C# og Uno Platform som frontend framework, udviklede jeg et program til at registrere Prompts til AI's.",
                "Disse prompts kunne så blive sendt til registrerede AI's, med udgangspunkt i OpenAI's ChatGPT, hvorefter deres svar bliver gemt til statistik.",
                "",
                "Programmets mål var at indsamle kvantitativ data på hvordan AI's svarer på den samme prompt, før Nørgård Mikkelsen forsøger at påvirke deres svar.",
                "Projektet er Open Source, og kan findes på min GitHub profil."),

            [EmploymentKey.WORK_DESCRIPTION_TV2.ToKey()] = Paragraphs(
                "Som en del af et Scrum-team arbejdede jeg med udvikling og vedligeholdelse af interne softwareværktøjer til TV 2's sports- og nyhedsdækning. " +
                "Jeg arbejdede primært med TypeScript og React, herunder videreudvikling og modernisering af eksisterende løsninger.",
                "",
                "På CasparCG ClipTool-projektet omskrev jeg frontend for at forbedre projektstrukturen og begrænse antallet af komponenter til én per fil, så koden blev lettere at navigere i og vedligeholde. " +
                "Jeg forbedrede også backendens håndtering af indstillinger mellem sessioner, rettede flere fejl og introducerede muligheden for at skjule udvalgte filer i brugergrænsefladen.",
                "",
                "På Sofie-projektet arbejdede jeg med backendfunktionalitet, herunder integration med MongoDB og det præsentationslag, som frontend benyttede. " +
                "Jeg hjalp også med at flytte virksomhedsspecifik kode fra det gamle repository til den nye struktur.",
                "",
                "Under min ansættelse fik jeg erfaring med samarbejds- og planlægningsværktøjer som Jira, Confluence og Lucidchart. " +
                "Jeg gik desuden fra ingen erfaring med TypeScript til at være næsten lige så komfortabel med det som med C#."),
            [EmploymentKey.WORK_DESCRIPTION_FLOWPOINT_DEFENCE.ToKey()] = Paragraphs(
                "Da jeg er underlagt NDA, kan jeg kun nævne at jeg hjalp med udviklingen af software i C#, til at automatisere processer for flåden."),
            [EmploymentKey.EMPLOYER_ODENSE_MOBIL_REP.ToKey()] = "Odense Mobil Rep",
            [EmploymentKey.JOB_TITLE_ODENSE_MOBIL_REP.ToKey()] = "Software Udvikler",
            [EmploymentKey.WORK_DESCRIPTION_ODENSE_MOBIL_REP.ToKey()] = Paragraphs(
                "Udviklede på ca. 54 timer et komplet desktopprogram til registrering af mobilreparationer i C#/.NET 10 med Uno Platform og Entity Framework Core (SQLite).",
                "",
                "Benyttede AI, primært ChatGPT, til sparring, kodegennemgang og dele af implementeringen, mens jeg selv stod for arkitektur, tekniske beslutninger, integration, test og kvalitetssikring.",
                "", "Projektet er offentligt tilgængeligt på GitHub:"),
            [EmploymentKey.EMPLOYER_MIITECH.ToKey()] = "MiiTech",
            [EmploymentKey.JOB_TITLE_MIITECH.ToKey()] = "Softwareudvikler",
            [EmploymentKey.WORK_DESCRIPTION_MIITECH.ToKey()] = Paragraphs(
                "Virksomhedspraktik med fokus på softwareudvikling og vedligeholdelse af eksisterende løsninger. " +
                "Arbejdsopgaverne forventes blandt andet at involvere PHP, Python og WordPress."),
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
                "Styrkede mine kompetencer inden for C#, Entity Framework Core og Uno Platform gennem flere udviklingsprojekter, herunder REST API'er, et fullstack lagerstyringssystem og forskellige mindre applikationer. Arbejdede både selvstændigt og i grupper og fik desuden introduktion til COBOL."),
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
            [UserInterfaceKey.ADDRESS_LABEL.ToKey()] = "Adresse",
            [UserInterfaceKey.GENERAL_HEADER.ToKey()] = "Generel Information",
            [UserInterfaceKey.PROJECTS_HEADER.ToKey()] = "Projekter",
            [UserInterfaceKey.DATE_OF_BIRTH_LABEL.ToKey()] = "Fødselsdag",
            [UserInterfaceKey.NAME_LABEL.ToKey()] = "Fulde Navn",
            [UserInterfaceKey.THE_LABEL.ToKey()] = "den",
            [UserInterfaceKey.OF_LABEL.ToKey()] = ".",
            [UserInterfaceKey.COURSES_HEADER.ToKey()] = "Kurser",
            [UserInterfaceKey.TOTAL_HOURS_LABEL.ToKey()] = "Timer i alt",
        };

        public static Dictionary<string, string> All { get; } = Merge(Links, Profile, Education, Employment,
            GeneralInformation, Languages, Projects, References, UserInterface, Courses);
    }
}
