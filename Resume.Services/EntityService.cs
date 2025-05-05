using Resume.Entities;
using Resume.Entities.Abstractions.Enums;
using Resume.Entities.Abstractions.Interfaces;
using Resume.Localization.Abstractions;
using Resume.Services.Abstractions;

namespace Resume.Services;

public class EntityService : IEntityService
{
    private readonly ILocaleService localeService;
    private readonly ILocalizationCategories categories;

    public EntityService(ILocaleService localeService, ILocalizationCategories categories)
    {
        this.localeService = localeService;
        this.categories = categories;
    }

    /// <inheritdoc />
    public IGeneralInformation GetGeneralInformation()
    {
        return new GeneralInformation()
        {
            FirstName = "André",
            MiddleName = "Steenhoff",
            LastName = "Madsen",
            Email = "andre@steenhoff.dk",
            City = "Odense V",
            Address = "Duftrankevej 17 2. mf",
            Country = localeService.GetLocalizedString(categories.GeneralInformationKeys.Country),
            PhoneNumber = 22287257,
            PostalCode = 5200,
            DateOfBirth = new DateTime(1996, 2, 3),
        };
    }

    /// <inheritdoc />
    public IList<IEmployment> GetEmployments()
    {
        var employments = new List<IEmployment>()
        {
            new Employment()
            {
                City = "Svendborg",
                Employer = localeService.GetLocalizedString(categories.EmploymentKeys.EmployerApps4All),
                JobTitle = localeService.GetLocalizedString(categories.EmploymentKeys.JobTitleApps4All),
                StartDate = new DateTime(2020, 10, 1),
                EndDate = new DateTime(2020, 12, 31),
                WorkDescription = localeService.GetLocalizedString(categories.EmploymentKeys.WorkDescriptionApps4All),
            },
            new Employment()
            {
                City = "Odense",
                Employer = localeService.GetLocalizedString(categories.EmploymentKeys.EmployerTv2),
                JobTitle = localeService.GetLocalizedString(categories.EmploymentKeys.JobTitleTv2),
                StartDate = new DateTime(2022, 4, 1),
                EndDate = new DateTime(2023, 12, 31),
                WorkDescription = localeService.GetLocalizedString(categories.EmploymentKeys.WorkDescriptionTv2),
                Links = new List<string>()
                {
                    localeService.GetLocalizedString(categories.LinkKeys.Tv2CliptoolGitHubProject),
                    localeService.GetLocalizedString(categories.LinkKeys.Tv2SofieServerGitHubProject),
                    localeService.GetLocalizedString(categories.LinkKeys.Tv2SofieAngularGitHubProject),
                },
            },
            new Employment()
            {
                City = "Odense",
                Employer = localeService.GetLocalizedString(categories.EmploymentKeys.EmployerFashionheroInternship),
                JobTitle = localeService.GetLocalizedString(categories.EmploymentKeys.JobTitleFashionheroInternship),
                StartDate = new DateTime(2024, 5, 6),
                EndDate = new DateTime(2024, 5, 31),
                WorkDescription =
                    localeService.GetLocalizedString(categories.EmploymentKeys.WorkDescriptionFashionheroInternship),
                Links = new List<string>()
                {
                    localeService.GetLocalizedString(categories.LinkKeys.FashionHeroGitHubProject),
                },
            },
            new Employment()
            {
                City = "Odense",
                Employer = localeService.GetLocalizedString(categories.EmploymentKeys
                    .EmployerNoergaardMikkelsenInternship),
                JobTitle = localeService.GetLocalizedString(categories.EmploymentKeys
                    .JobTitleNoergaardMikkelsenInternship),
                StartDate = new DateTime(2025, 3, 17),
                EndDate = new DateTime(2025, 4, 11),
                WorkDescription =
                    localeService.GetLocalizedString(categories.EmploymentKeys
                        .WorkDescriptionNoergaardMikkelsenInternship),
                Links = new List<string>()
                {
                    localeService.GetLocalizedString(categories.LinkKeys.NoergaardMikkelsenGitHubProject),
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
        var skills = new List<ISkill>()
        {
            new Skill()
            {
                Name = "C#",
                Importance = 100,
                Expertise = SkillLevel.EXPERIENCED,
            },
            new Skill()
            {
                Name = "TypeScript",
                Importance = 90,
                Expertise = SkillLevel.EXPERIENCED,
            },
            new Skill()
            {
                Name = "Python",
                Importance = 30,
                Expertise = SkillLevel.NOVICE,
            },
            new Skill()
            {
                Name = "Java",
                Importance = 35,
                Expertise = SkillLevel.NOVICE,
            },
            new Skill()
            {
                Name = "JavaScript",
                Importance = 50,
                Expertise = SkillLevel.SKILLFUL,
            },
            new Skill()
            {
                Name = "SCRUM",
                Importance = 60,
                Expertise = SkillLevel.SKILLFUL,
            },
            new Skill()
            {
                Name = "Git",
                Importance = 65,
                Expertise = SkillLevel.EXPERIENCED,
            },
            new Skill()
            {
                Name = "C++",
                Importance = 25,
                Expertise = SkillLevel.NOVICE,
            },
            new Skill()
            {
                Name = "SQL",
                Importance = 55,
                Expertise = SkillLevel.SKILLFUL,
            },
            new Skill()
            {
                Name = "Angular",
                Importance = 45,
                Expertise = SkillLevel.NOVICE,
            },
            new Skill()
            {
                Name = "Elastic Search",
                Importance = 20,
                Expertise = SkillLevel.NOVICE,
            },
            new Skill()
            {
                Name = "Uno Platform / Maui",
                Importance = 80,
                Expertise = SkillLevel.EXPERIENCED,
            },
            new Skill()
            {
                Name = "Entity Framework Core",
                Importance = 80,
                Expertise = SkillLevel.EXPERIENCED,
            },
        };

        skills.Sort();
        return skills;
    }

    /// <inheritdoc />
    public IList<ILink> GetLinks()
    {
        var links = new List<ILink>()
        {
            new Link()
            {
                Importance = 100,
                Title = localeService.GetLocalizedString(categories.LinkKeys.TitleGitHub),
                Remark = localeService.GetLocalizedString(categories.LinkKeys.RemarkGitHub),
                Url = localeService.GetLocalizedString(categories.LinkKeys.PersonalGithub),
            },
            new Link()
            {
                Importance = 80,
                Title = localeService.GetLocalizedString(categories.LinkKeys.TitleLinkedIn),
                Remark = localeService.GetLocalizedString(categories.LinkKeys.RemarkLinkedIn),
                Url = localeService.GetLocalizedString(categories.LinkKeys.PersonalLinkedIn),
            },
            new Link()
            {
                Importance = 90,
                Title = localeService.GetLocalizedString(categories.LinkKeys.TitlePersonalPage),
                Remark = localeService.GetLocalizedString(categories.LinkKeys.RemarkPersonalPage),
                Url = localeService.GetLocalizedString(categories.LinkKeys.PersonalPage),
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
            new Reference()
            {
                Name = "Henrik Dudek",
                Company = localeService.GetLocalizedString(categories.ReferencesKeys.CompanyNameTv2),
                Email = "hedu@tv2.dk",
                Importance = 50,
                IsShown = false,
            },
            new Reference()
            {
                Name = "Jeppe Hamming",
                Company = localeService.GetLocalizedString(categories.ReferencesKeys.CompanyNameNoergaardMikkelsen),
                Email = "jeppe.hamming@nmic.dk",
                Importance = 70,
                IsShown = true,
            },
        };

        references.Sort();
        return references;
    }

    /// <inheritdoc />
    public IList<ILanguage> GetLanguages()
    {
        var languages = new List<ILanguage>()
        {
            new Language()
            {
                Name = localeService.GetLocalizedString(categories.LanguageKeys.DanishLanguage),
                Level = LanguageLevel.NATIVE_SPEAKER,
                Importance = 100,
            },
            new Language()
            {
                Name = localeService.GetLocalizedString(categories.LanguageKeys.EnglishLanguage),
                Level = LanguageLevel.HIGHLY_PROFICIENT,
                Importance = 80,
            },
            new Language()
            {
                Name = localeService.GetLocalizedString(categories.LanguageKeys.GermanLanguage),
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
        var educations = new List<IEducation>()
        {
            new Education()
            {
                City = "Odense",
                Grade = localeService.GetLocalizedString(categories.EducationKeys.GradeBachelor),
                Description = localeService.GetLocalizedString(categories.EducationKeys.DescriptionBachelor),
                SchoolName = localeService.GetLocalizedString(categories.EducationKeys.SchoolNameUcl),
                StartDate = new DateTime(2019, 2, 1),
                EndDate = new DateTime(2020, 6, 19),
            },
            new Education()
            {
                City = "Odense",
                Grade = localeService.GetLocalizedString(categories.EducationKeys.GradeSoftware),
                Description = localeService.GetLocalizedString(categories.EducationKeys.DescriptionSoftware),
                SchoolName = localeService.GetLocalizedString(categories.EducationKeys.SchoolNameUcl),
                StartDate = new DateTime(2016, 9, 1),
                EndDate = new DateTime(2019, 1, 31),
            },
            new Education()
            {
                City = "Svendborg",
                Grade = localeService.GetLocalizedString(categories.EducationKeys.GradeHtx),
                Description = localeService.GetLocalizedString(categories.EducationKeys.DescriptionHtx),
                SchoolName = localeService.GetLocalizedString(categories.EducationKeys.SchoolNameHtx),
                StartDate = new DateTime(2013, 9, 1),
                EndDate = new DateTime(2016, 6, 17),
            },
        };

        educations.Sort();
        return educations;
    }

    /// <inheritdoc />
    public IList<IProject> GetProjects()
    {
        var projects = new List<IProject>()
        {
            new Project()
            {
                Name = localeService.GetLocalizedString(categories.ProjectKeys.TrackerDescription),
                Description = localeService.GetLocalizedString(categories.ProjectKeys.TrackerDescription),
                Importance = 100,
            },
            new Project()
            {
                Name = localeService.GetLocalizedString(categories.ProjectKeys.OniModdingTitle),
                Description = localeService.GetLocalizedString(categories.ProjectKeys.OniModdingDescription),
                Importance = 90,
            },
            new Project()
            {
                Name = localeService.GetLocalizedString(categories.ProjectKeys.TowerDefenceDevTitle),
                Description = localeService.GetLocalizedString(categories.ProjectKeys.TowerDefenceDevDescription),
                Importance = 80,
            },
        };

        projects.Sort();
        return projects;
    }
}
