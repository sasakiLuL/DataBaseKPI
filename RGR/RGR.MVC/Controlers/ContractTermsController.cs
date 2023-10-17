using RGR.MVC.Controlers.BaseControler;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos;
using RGR.MVC.Views;

namespace RGR.MVC.Controlers
{
    public class ContractTermsController : Controller<ContractTerms>
    {
        public ContractTermsController(ContractTermsRepo repo, ContractTermsView view) : base(repo, view) { }

        public void AddContractTerms(long id, string ContractName, decimal Price, string Description, long GymId)
        {
            AddEntity(new ContractTerms() { ContractName = ContractName, Price = Price, Description = Description, GymId = GymId });
        }

        public void PrintAllContractsTerms()
        {
            PrintAllEntities();
        }

        public void UpdateContractTerms(long id, string ContractName, decimal Price, string Description, long GymId)
        {
            UpdateEntity(id, new ContractTerms() { ContractName = ContractName, Price = Price, Description = Description, GymId = GymId });
        }

        public void DeleteContractTerms(long id)
        {
            DeleteEntity(id);
        }
    }
}

