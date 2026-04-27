using Resume.Abstraction.Interfaces.Resume;

namespace Resume.Abstraction.Interfaces.Services
{
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

        IList<ICourse> GetCourses();
    }
}
