using Resume.Entities.Abstractions.Interfaces;

namespace Resume.Services.Abstractions;

public interface IEntityService
{
    IGeneralInformation GetGeneralInformation();
    IList<IEmployment> GetEmployments();
    IList<ISkill> GetSkills();
    IList<ILink> GetLinks();
    IList<IReference> GetReferences();
    IList<ILanguage> GetLanguages();
    IList<IEducation> GetEducations();
    IList<IProject> GetProjects();
}
