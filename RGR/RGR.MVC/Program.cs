using Npgsql;
using RGR.Dal.Repos;
using RGR.MVC.Views;

NpgsqlConnection npgsqlConnection = new NpgsqlConnection()
{
    ConnectionString = "host=localhost;port=5433;database=appoi_db;user id=postgres;password=pass12345"
};

ClassRepo classRepo = new(npgsqlConnection);
UserRepo userRepo = new(npgsqlConnection);
GymRepo gymRepo = new(npgsqlConnection);
CoachRepo coachRepo = new(npgsqlConnection);

ClassView classView = new(classRepo.FindAll());
UserView userView = new(userRepo.FindAll());
GymView gymView = new(gymRepo.FindAll());
CoachView coachView = new(coachRepo.FindAll());

classView.Print();
userView.Print();
gymView.Print();
coachView.Print();

return;
