using RGR.Dal.Models.Entities;
using RGR.MVC.Views.BaseView;

namespace RGR.MVC.Views
{
    public class CourseView : BaseView<Course>
    {
        public CourseView(IEnumerable<Course> entities) : base(entities) { }
    }
}
