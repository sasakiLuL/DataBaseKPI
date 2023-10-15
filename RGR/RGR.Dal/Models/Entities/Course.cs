using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGR.Dal.Models.Entities
{
    [Table("courses")]
    public class Course
    {
        [Key]
        [Column("course_id")]
        public long CourseId { get; set; }

        [Column("course_name")]
        public string CourseName { get; set; } = null!;
    }
}
