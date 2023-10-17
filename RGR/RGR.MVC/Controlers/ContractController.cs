using RGR.MVC.Controlers.BaseControler;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos;
using RGR.MVC.Views;

namespace RGR.MVC.Controlers
{
    public class ContractController : Controller<Contract>
    {
        public ContractController(ContractRepo repo, ContractView view) : base(repo, view) { }

        public void AddContract(DateTime TransactionTime, string PaymentMethod, long? UserId, long? ContractTermsId)
        {
            AddEntity(new Contract() { TransactionTime = TransactionTime, PaymentMethod = PaymentMethod, UserId = UserId, ContractTermsId = ContractTermsId });
        }

        public void PrintAllContracts()
        {
            PrintAllEntities();
        }

        public void UpdateContract(long id, DateTime TransactionTime, string PaymentMethod, long? UserId, long? ContractTermsId)
        {
            UpdateEntity(id, new Contract() { TransactionTime = TransactionTime, PaymentMethod = PaymentMethod, UserId = UserId, ContractTermsId = ContractTermsId });
        }

        public void DeleteContract(long id)
        {
            DeleteEntity(id);
        }
    }
}
