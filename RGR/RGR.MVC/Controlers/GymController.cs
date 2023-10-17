using RGR.MVC.Controlers.BaseControler;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos;
using RGR.MVC.Views;

namespace RGR.MVC.Controlers
{
    public class GymController : Controller<Gym>
    {
        public GymController(GymRepo repo, GymView view) : base(repo, view) { }

        public void AddGym(string GymName, string? Description, string GymType, string Address, string? HomePage, string PhoneNumber, string? Email)
        {
            AddEntity(new Gym() { GymName = GymName, Description = Description, GymType = GymType, Address = Address, HomePage = HomePage, Email = Email, PhoneNumber = PhoneNumber });
        }

        public void PrintAllGyms()
        {
            PrintAllEntities();
        }

        public void UpdateGym(long id, string GymName, string? Description, string GymType, string Address, string? HomePage, string PhoneNumber, string? Email)
        {
            UpdateEntity(id, new Gym() { GymName = GymName, Description = Description, GymType = GymType, Address = Address, HomePage = HomePage, Email = Email, PhoneNumber = PhoneNumber });
        }

        public void DeleteGym(long id)
        {
            DeleteEntity(id);
        }
    }
}



