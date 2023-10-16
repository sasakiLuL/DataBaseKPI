using RGR.Dal.Models.Entities;
using RGR.MVC.Views.BaseView;

namespace RGR.MVC.Views
{
    public class GymView : BaseView<Gym>
    {
        public GymView(IEnumerable<Gym> entities) : base(entities) { }
    }
}
