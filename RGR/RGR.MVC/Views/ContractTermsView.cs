using RGR.Dal.Models.Entities;
using RGR.MVC.Views.BaseView;

namespace RGR.MVC.Views
{
    public class ContractTermsView : BaseView<ContractTerms>
    {
        public ContractTermsView(IEnumerable<ContractTerms> entities) : base(entities) { }
    }
}
