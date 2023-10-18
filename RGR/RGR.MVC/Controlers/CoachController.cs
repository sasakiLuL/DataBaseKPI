using RGR.MVC.Controlers.BaseControler;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos;
using RGR.MVC.Views;

namespace RGR.MVC.Controlers
{
    public class CoachController : Controller<Coach>
    {
        public CoachController(CoachRepo repo, CoachView view) : base(repo, view) { }

        public void AddCoach(string FirstName, string LastName, string? Description, DateTime EmploymentDate, long GymId)
        {
            AddEntity(new Coach() { FirstName = FirstName, LastName = LastName, Description = Description, EmploymentDate = EmploymentDate, GymId = GymId });
        }

        public void PrintAllCoaches()
        {
            PrintAllEntities();
        }

        public void UpdateCoach(long id, string FirstName, string LastName, string? Description, DateTime EmploymentDate, long GymId)
        {
            UpdateEntity(id, new Coach() { FirstName = FirstName, LastName = LastName, Description = Description, EmploymentDate = EmploymentDate, GymId = GymId });
        }

        public void DeleteCoach(long id)
        {
            DeleteEntity(id);
        }
    }
}
