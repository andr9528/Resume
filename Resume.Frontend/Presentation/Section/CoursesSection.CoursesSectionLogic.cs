using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation.Section;

public partial class CoursesSection
{
    private class CoursesSectionLogic : BaseLogic<CoursesSectionViewModel>
    {
        public CoursesSectionLogic(CoursesSectionViewModel viewModel) : base(viewModel)
        {
        }
    }
}
