using Resume.Abstraction.Enums;
using Resume.Abstraction.Enums.Keys;
using Resume.Abstraction.Interfaces.Resume;
using Resume.Abstraction.Interfaces.Services;
using Resume.Entities;
using Resume.Entities.Resume;
using Resume.Models.Extensions;
using Resume.Models.Resume;

namespace Resume.Services;

public class EntityService : IEntityService
{
    private readonly ILocaleService localeService;

    public EntityService(ILocaleService localeService)
    {
        this.localeService = localeService;
    }

    /// <inheritdoc />
    public IGeneralInformation GetGeneralInformation()
    {
        return new GeneralInformation
        {
            FirstName = "André",
            MiddleName = "Steenhoff",
            LastName = "Madsen",
            Email = "andre@steenhoff.dk",
            City = "Odense V",
            Address = "Duftrankevej 17 2. mf",
            Country = localeService.GetLocalizedString(GeneralInformationKey.COUNTRY.ToKey()),
            PhoneNumber = 22287257,
            PostalCode = 5200,
            DateOfBirth = new DateTime(1996, 2, 3),
        };
    }

    /// <inheritdoc />
    public IList<IEmployment> GetEmployments()
    {
        var employments = new List<IEmployment>
        {
            new Employment
            {
                City = "Svendborg",
                Employer = localeService.GetLocalizedString(EmploymentKey.EMPLOYER_APPS4ALL.ToKey()),
                JobTitle = localeService.GetLocalizedString(EmploymentKey.JOB_TITLE_APPS4ALL.ToKey()),
                StartDate = new DateTime(2020, 10, 1),
                EndDate = new DateTime(2020, 12, 31),
                WorkDescription = localeService.GetLocalizedString(EmploymentKey.WORK_DESCRIPTION_APPS4ALL.ToKey()),
                EmploymentType = localeService.GetLocalizedString(EmploymentKey.EMPLOYMENT_TYPE_CONTRACT.ToKey()),
            },
            new Employment
            {
                City = "Odense",
                Employer = localeService.GetLocalizedString(EmploymentKey.EMPLOYER_TV2.ToKey()),
                JobTitle = localeService.GetLocalizedString(EmploymentKey.JOB_TITLE_TV2.ToKey()),
                StartDate = new DateTime(2022, 4, 1),
                EndDate = new DateTime(2023, 12, 31),
                WorkDescription = localeService.GetLocalizedString(EmploymentKey.WORK_DESCRIPTION_TV2.ToKey()),
                EmploymentType = localeService.GetLocalizedString(EmploymentKey.EMPLOYMENT_TYPE_CONTRACT.ToKey()),
                Links = new List<string>
                {
                    localeService.GetLocalizedString(LinkKey.TV2_CLIPTOOL_GITHUB_PROJECT.ToKey()),
                },
            },
            new Employment
            {
                City = "Odense",
                Employer = localeService.GetLocalizedString(EmploymentKey.EMPLOYER_FASHIONHERO_INTERNSHIP.ToKey()),
                JobTitle = localeService.GetLocalizedString(EmploymentKey.JOB_TITLE_FASHIONHERO_INTERNSHIP.ToKey()),
                StartDate = new DateTime(2024, 5, 6),
                EndDate = new DateTime(2024, 5, 31),
                WorkDescription =
                    localeService.GetLocalizedString(EmploymentKey.WORK_DESCRIPTION_FASHIONHERO_INTERNSHIP.ToKey()),

                EmploymentType = localeService.GetLocalizedString(EmploymentKey.EMPLOYMENT_TYPE_INTERNSHIP.ToKey()),
                Links = new List<string>
                {
                    localeService.GetLocalizedString(LinkKey.FASHION_HERO_GITHUB_PROJECT.ToKey()),
                },
            },
            new Employment
            {
                City = "Odense",
                Employer = localeService.GetLocalizedString(
                    EmploymentKey.EMPLOYER_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()),
                JobTitle = localeService.GetLocalizedString(
                    EmploymentKey.JOB_TITLE_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()),
                StartDate = new DateTime(2025, 3, 17),
                EndDate = new DateTime(2025, 4, 11),
                WorkDescription =
                    localeService.GetLocalizedString(
                        EmploymentKey.WORK_DESCRIPTION_NOERGAARD_MIKKELSEN_INTERNSHIP.ToKey()),
                EmploymentType = localeService.GetLocalizedString(EmploymentKey.EMPLOYMENT_TYPE_INTERNSHIP.ToKey()),
                Links = new List<string>
                {
                    localeService.GetLocalizedString(LinkKey.NOERGAARD_MIKKELSEN_GITHUB_PROJECT.ToKey()),
                },
            },
        };

        employments.Sort();
        employments.Reverse();
        return employments;
    }

    /// <inheritdoc />
    public IList<ISkill> GetSkills()
    {
        var skills = new List<ISkill>
        {
            new Skill
            {
                Name = "C#",
                Importance = 100,
                Expertise = SkillLevel.EXPERIENCED,
            },
            new Skill
            {
                Name = "TypeScript",
                Importance = 90,
                Expertise = SkillLevel.EXPERIENCED,
            },
            new Skill
            {
                Name = "Python",
                Importance = 25,
                Expertise = SkillLevel.NOVICE,
            },
            new Skill
            {
                Name = "Java",
                Importance = 35,
                Expertise = SkillLevel.NOVICE,
            },
            new Skill
            {
                Name = "JavaScript",
                Importance = 50,
                Expertise = SkillLevel.SKILLFUL,
            },
            new Skill
            {
                Name = "SCRUM",
                Importance = 60,
                Expertise = SkillLevel.SKILLFUL,
            },
            new Skill
            {
                Name = "Git",
                Importance = 65,
                Expertise = SkillLevel.EXPERIENCED,
            },
            new Skill
            {
                Name = "C++",
                Importance = 25,
                Expertise = SkillLevel.NOVICE,
            },
            new Skill
            {
                Name = "SQL",
                Importance = 55,
                Expertise = SkillLevel.SKILLFUL,
            },
            new Skill
            {
                Name = "Angular",
                Importance = 25,
                Expertise = SkillLevel.NOVICE,
            },
            new Skill
            {
                Name = "Elastic Search",
                Importance = 20,
                Expertise = SkillLevel.NOVICE,
            },
            new Skill
            {
                Name = "Uno Platform / Maui",
                Importance = 80,
                Expertise = SkillLevel.EXPERIENCED,
            },
            new Skill
            {
                Name = "Entity Framework Core",
                Importance = 80,
                Expertise = SkillLevel.EXPERIENCED,
            },
            new Skill
            {
                Name = "COBOL",
                Importance = 30,
                Expertise = SkillLevel.NOVICE,
            },
            new Skill
            {
                Name = "NUnit / TUnit / XUnit",
                Importance = 60,
                Expertise = SkillLevel.SKILLFUL,
            },
            new Skill
            {
                Name = "Fluent Assertion",
                Importance = 59,
                Expertise = SkillLevel.SKILLFUL,
            },
        };

        skills.Sort();
        skills.Reverse();
        return skills;
    }

    /// <inheritdoc />
    public IList<ILink> GetLinks()
    {
        var links = new List<ILink>
        {
            new Link
            {
                Importance = 100,
                Title = localeService.GetLocalizedString(LinkKey.TITLE_GITHUB.ToKey()),
                Remark = localeService.GetLocalizedString(LinkKey.REMARK_GITHUB.ToKey()),
                Url = localeService.GetLocalizedString(LinkKey.PERSONAL_GITHUB.ToKey()),
            },
            new Link
            {
                Importance = 80,
                Title = localeService.GetLocalizedString(LinkKey.TITLE_LINKEDIN.ToKey()),
                Remark = localeService.GetLocalizedString(LinkKey.REMARK_LINKEDIN.ToKey()),
                Url = localeService.GetLocalizedString(LinkKey.PERSONAL_LINKEDIN.ToKey()),
            },
            new Link
            {
                Importance = 90,
                Title = localeService.GetLocalizedString(LinkKey.TITLE_PERSONAL_PAGE.ToKey()),
                Remark = localeService.GetLocalizedString(LinkKey.REMARK_PERSONAL_PAGE.ToKey()),
                Url = localeService.GetLocalizedString(LinkKey.PERSONAL_PAGE.ToKey()),
            },
        };

        links.Sort();
        return links;
    }

    /// <inheritdoc />
    public IList<IReference> GetReferences()
    {
        var references = new List<IReference>
        {
            // Henrik Dudek is no longer employed at TV2, and therefore no longer has access to the TV2 email.
            new Reference
            {
                Name = "Henrik Dudek",
                Company = localeService.GetLocalizedString(ReferencesKey.COMPANY_NAME_TV2.ToKey()),
                Email = "hedu@tv2.dk",
                Importance = 50,
                IsShown = false,
            },
            new Reference
            {
                Name = "Jeppe Hamming",
                Company = localeService.GetLocalizedString(ReferencesKey.COMPANY_NAME_NOERGAARD_MIKKELSEN.ToKey()),
                Email = "jeppe.hamming@nmic.dk",
                Importance = 40,
                IsShown = true,
            },
            new Reference
            {
                Name = "Marwa Kasim",
                Company = localeService.GetLocalizedString(ReferencesKey.COMPANY_NAME_SPECIALISTERNE.ToKey()),
                Email = "marwa.kasim@specialisterne.dk",
                Importance = 60,
                Phone = "+45 27 79 85 97",
                IsShown = true,
            },
        };

        references.Sort();
        references.Reverse();
        return references;
    }

    /// <inheritdoc />
    public IList<ILanguage> GetLanguages()
    {
        var languages = new List<ILanguage>
        {
            new Language
            {
                Name = localeService.GetLocalizedString(LanguageKey.DANISH_LANGUAGE.ToKey()),
                Level = LanguageLevel.NATIVE_SPEAKER,
                Importance = 100,
            },
            new Language
            {
                Name = localeService.GetLocalizedString(LanguageKey.ENGLISH_LANGUAGE.ToKey()),
                Level = LanguageLevel.HIGHLY_PROFICIENT,
                Importance = 80,
            },
            new Language
            {
                Name = localeService.GetLocalizedString(LanguageKey.GERMAN_LANGUAGE.ToKey()),
                Level = LanguageLevel.WORKING_KNOWLEDGE,
                Importance = 50,
            },
        };

        languages.Sort();
        return languages;
    }

    /// <inheritdoc />
    public IList<IEducation> GetEducations()
    {
        var educations = new List<IEducation>
        {
            new Education
            {
                City = "Odense",
                Grade = localeService.GetLocalizedString(EducationKey.GRADE_BACHELOR.ToKey()),
                Description = localeService.GetLocalizedString(EducationKey.DESCRIPTION_BACHELOR.ToKey()),
                SchoolName = localeService.GetLocalizedString(EducationKey.SCHOOL_NAME_UCL.ToKey()),
                StartDate = new DateTime(2019, 2, 1),
                EndDate = new DateTime(2020, 6, 19),
            },
            new Education
            {
                City = "Odense",
                Grade = localeService.GetLocalizedString(EducationKey.GRADE_SOFTWARE.ToKey()),
                Description = localeService.GetLocalizedString(EducationKey.DESCRIPTION_SOFTWARE.ToKey()),
                SchoolName = localeService.GetLocalizedString(EducationKey.SCHOOL_NAME_UCL.ToKey()),
                StartDate = new DateTime(2016, 9, 1),
                EndDate = new DateTime(2019, 1, 31),
            },
            new Education
            {
                City = "Svendborg",
                Grade = localeService.GetLocalizedString(EducationKey.GRADE_HTX.ToKey()),
                Description = localeService.GetLocalizedString(EducationKey.DESCRIPTION_HTX.ToKey()),
                SchoolName = localeService.GetLocalizedString(EducationKey.SCHOOL_NAME_HTX.ToKey()),
                StartDate = new DateTime(2013, 9, 1),
                EndDate = new DateTime(2016, 6, 17),
            },
        };

        educations.Sort();
        educations.Reverse();
        return educations;
    }

    /// <inheritdoc />
    public IList<IProject> GetProjects()
    {
        var projects = new List<IProject>
        {
            new Project
            {
                Name = localeService.GetLocalizedString(ProjectKey.TRACKER_TITLE.ToKey()),
                Description = localeService.GetLocalizedString(ProjectKey.TRACKER_DESCRIPTION.ToKey()),
                Importance = 100,
            },
            new Project
            {
                Name = localeService.GetLocalizedString(ProjectKey.ONI_MODDING_TITLE.ToKey()),
                Description = localeService.GetLocalizedString(ProjectKey.ONI_MODDING_DESCRIPTION.ToKey()),
                Importance = 90,
            },
            new Project
            {
                Name = localeService.GetLocalizedString(ProjectKey.TOWER_DEFENCE_DEV_TITLE.ToKey()),
                Description = localeService.GetLocalizedString(ProjectKey.TOWER_DEFENCE_DEV_DESCRIPTION.ToKey()),
                Importance = 80,
            },
        };

        projects.Sort();
        return projects;
    }
}
