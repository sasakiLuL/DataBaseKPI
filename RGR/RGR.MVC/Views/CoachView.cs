using RGR.Dal.Models.Entities;
using RGR.MVC.Views.BaseView;

namespace RGR.MVC.Views
{
    public class CoachView : BaseView<Coach>
    {
        public CoachView(IEnumerable<Coach> entities) : base(entities) { }
    }
}