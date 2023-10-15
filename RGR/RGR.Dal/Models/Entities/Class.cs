using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGR.Dal.Models.Entities
{
    [Table("classes")]
    public class Class
    {
        [Key]
        [Column("class_id")]
        public long ClassId { get; set; }

        [Column("max_participants")] 
        public int MaxParticipants { get; set; }

        [Column("start_time")] 
        public DateTime? StartTime { get; set; }

        [Column("end_time")] 
        public DateTime? EndTime { get; set; }

        [Column("course_id")] 
        public long CourseId { get; set; }
    }
}
