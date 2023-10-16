using RGR.Dal.Models.Entities;
using RGR.MVC.Views.BaseView;

namespace RGR.MVC.Views
{
    public class UserView : BaseView<User>
    {
        public UserView(IEnumerable<User> entities) : base(entities) { }
    }
}

