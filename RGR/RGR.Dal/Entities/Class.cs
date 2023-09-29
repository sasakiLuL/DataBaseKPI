using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAppoi.Models.Entities
{
    public class Class
    {
        public int ClassId { get; set; }
        public int MaxParticipants { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public IEnumerable<User> Participants { get; set; } = new List<User>();
        public IEnumerable<Coach> Coaches { get; set; } = new List<Coach>();
    }
}
