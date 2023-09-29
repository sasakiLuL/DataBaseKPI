using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RGR.Dal.ORM;

namespace GAppoi.Models.Entities
{
    public class Course
    {
        [DataNames("course_id")] public int CourseId { get; set; }
        [DataNames("course_name")] public string CourseName { get; set; } = null!;
        public IEnumerable<Class> Classes { get; set; } = new List<Class>();
        public IEnumerable<ContractTerms> ContractsTerms { get; set; } = new List<ContractTerms>();
    }
}
