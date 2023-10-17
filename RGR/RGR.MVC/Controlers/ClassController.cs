using RGR.MVC.Controlers.BaseControler;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos;
using RGR.MVC.Views;

namespace RGR.MVC.Controlers
{
    public class ClassController : Controller<Class>
    {
        public ClassController(ClassRepo repo, ClassView view) : base(repo, view) { }

        public void AddClass(int MaxParticipants, long Course_id,
            DateTime? StartTime = null, DateTime? EndTime = null)
        {
            AddEntity(new Class() { CourseId = Course_id, EndTime = EndTime, MaxParticipants = MaxParticipants, StartTime = StartTime });
        }

        public void PrintAllClasses()
        {
            PrintAllEntities();
        }

        public void UpdateClass(long id, int MaxParticipants, long Course_id,
            DateTime? StartTime = null, DateTime? EndTime = null)
        {
            UpdateEntity(id, new Class() { CourseId = Course_id, EndTime = EndTime, MaxParticipants = MaxParticipants, StartTime = StartTime });
        }

        public void DeleteClass(long id)
        {
            DeleteEntity(id);
        }
    }
}
