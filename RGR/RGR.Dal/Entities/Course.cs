using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GAppoi.Models.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public IEnumerable<Class> Classes { get; set; } = new List<Class>();
        public IEnumerable<ContractTerms> ContractsTerms { get; set; } = new List<ContractTerms>();
    }
}
