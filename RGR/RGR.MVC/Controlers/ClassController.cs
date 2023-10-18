using RGR.MVC.Controlers.BaseControler;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos;
using RGR.MVC.Views;
using RGR.Dal.Filters;
using Spectre.Console;

namespace RGR.MVC.Controlers
{
    public class ClassController : Controller<Class>
    {
        public ClassController(ClassRepo repo, ClassView view) : base(repo, view) { }

        public void AddClass(int MaxParticipants, long Course_id,
            DateTime StartTime, DateTime EndTime)
        {
            AddEntity(new Class() { CourseId = Course_id, EndTime = EndTime, MaxParticipants = MaxParticipants, StartTime = StartTime });
        }

        public void PrintFullClassInfoByClassIdRange(long f, long s)
        {
            try
            {
                var entities = ((ClassRepo)Repo).FindFullClassInfo
                    (filter: Filter<(Class Entity, string CourseName, long ParticipantCount)>.Value(v => v.Entity.ClassId)
                    .Between(f, s));
                ((ClassView)View).PrintFullClassInfo(entities.ToList());
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteLine(ex.ToString());
            }
        }

        public void PrintAllClasses()
        {
            PrintAllEntities();
        }

        public void UpdateClass(long id, int MaxParticipants, long Course_id,
            DateTime StartTime, DateTime EndTime)
        {
            UpdateEntity(id, new Class() { CourseId = Course_id, EndTime = EndTime, MaxParticipants = MaxParticipants, StartTime = StartTime });
        }

        public void DeleteClass(long id)
        {
            DeleteEntity(id);
        }
    }
}
