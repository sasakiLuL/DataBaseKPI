using RGR.MVC.Controlers.BaseControler;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos;
using RGR.MVC.Views;
using RGR.Dal.Filters;
using Spectre.Console;

namespace RGR.MVC.Controlers
{
    public class GymController : Controller<Gym>
    {
        public GymController(GymRepo repo, GymView view) : base(repo, view) { }

        public void AddGym(string GymName, string? Description, string? GymType, string Address, string? HomePage, string PhoneNumber, string? Email)
        {
            AddEntity(new Gym() { GymName = GymName, Description = Description, GymType = GymType, Address = Address, HomePage = HomePage, Email = Email, PhoneNumber = PhoneNumber });
        }

        public void PrintAllGyms()
        {
            PrintAllEntities();
        }

        public void PrintGymUsersAndCoachesCountByName(string likeFunc)
        {
            try
            {
                var entities = ((GymRepo)Repo).FindWithUserAndCoachesCount
                    (filter: Filter<(Gym Entity, long UsersCount, long CoachesCount)>.Value(v => v.Entity.GymName, "subq")
                    .Like(likeFunc));
                ((GymView)View).ViewAllWithUserAndCoachesCount(entities.ToList());
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteLine(ex.ToString());
            }
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



