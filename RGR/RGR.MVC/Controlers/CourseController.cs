using RGR.MVC.Controlers.BaseControler;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos;
using RGR.MVC.Views;

namespace RGR.MVC.Controlers
{
    public class CourseController : Controller<Course>
    {
        public CourseController(CourseRepo repo, CourseView view) : base(repo, view) { }

        public void AddCourse(string CourseName)
        {
            AddEntity(new Course() { CourseName = CourseName});
        }

        public void PrintAllCourses()
        {
            PrintAllEntities();
        }

        public void UpdateCourse(long id, string CourseName)
        {
            UpdateEntity(id, new Course() { CourseName = CourseName });
        }

        public void DeleteCourse(long id)
        {
            DeleteEntity(id);
        }
    }
}


