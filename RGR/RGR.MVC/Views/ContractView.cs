using RGR.Dal.Models.Entities;
using RGR.MVC.Views.BaseView;

namespace RGR.MVC.Views
{
    public class ContractView : BaseView<Contract>
    {
        public ContractView(IEnumerable<Contract> entities) : base(entities) { }
    }
}
