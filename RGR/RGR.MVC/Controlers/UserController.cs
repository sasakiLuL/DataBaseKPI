using RGR.MVC.Controlers.BaseControler;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos;
using RGR.MVC.Views;
using RGR.Dal.Filters;
using Spectre.Console;

namespace RGR.MVC.Controlers
{
    public class UserController : Controller<User>
    {
        public UserController(UserRepo repo, UserView view) : base(repo, view) { }

        public void AddUser(string FirstName, string LastName, int Sex, DateTime DateOfBirth, string Address, string PhoneNumber, string? Email)
        {
            AddEntity(new User() { FirstName = FirstName, LastName = LastName, Sex = Sex, DateOfBirth = DateOfBirth, Address = Address, PhoneNumber = PhoneNumber, Email = Email });
        }

        public void PrintUsersContractsByDateOfBirth(DateTime f, DateTime s)
        {
            try
            {
                var items = ((UserRepo)Repo).FindUsersContracts
                    (filter: Filter<(User Entity, long ContractsCount)>.Value(v => v.Entity.DateOfBirth)
                    .Between(f, s));
                ((UserView)View).PrintUsersContracts(items.Item1.ToList(), items.Item2);
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteLine(ex.ToString());
            }
        }

        public void PrintAllUsers()
        {
            PrintAllEntities();
        }

        public void UpdateUser(long id, string FirstName, string LastName, int Sex, DateTime DateOfBirth, string Address, string PhoneNumber, string? Email)
        {
            UpdateEntity(id, new User() { FirstName = FirstName, LastName = LastName, Sex = Sex, DateOfBirth = DateOfBirth, Address = Address, PhoneNumber = PhoneNumber, Email = Email });
        }

        public void DeleteUser(long id)
        {
            DeleteEntity(id);
        }
    }
}




