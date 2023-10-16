using RGR.Dal.Models.Entities;
using RGR.MVC.Views.BaseView;

namespace RGR.MVC.Views
{
    public class ClassView : BaseView<Class>
    {
        public ClassView(IEnumerable<Class> entities) : base(entities) { }
    }
}
