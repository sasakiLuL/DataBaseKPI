using RGR.Dal.ORM;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGR.Dal.Entities
{
    public class Class
    {
        [DataNames("class_id")] public int ClassId { get; set; }
        [DataNames("max_participants")] public int MaxParticipants { get; set; }
        [DataNames("start_time")] public DateTime StartTime { get; set; }
        [DataNames("end_time")] public DateTime EndTime { get; set; }
        [DataNames("course_id")] public int CourseId { get; set; }
        public Course Course { get; set; }
        public IEnumerable<User> Participants { get; set; } = new List<User>();
        public IEnumerable<Coach> Coaches { get; set; } = new List<Coach>();
    }
}
