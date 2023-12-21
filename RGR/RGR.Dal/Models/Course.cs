using System;
using System.Collections.Generic;

namespace RGR.Dal.Models;

public partial class Course
{
    public Course()
    {
        
    }

    public Course(long courseId, string courseName, long gymId)
    {
        CourseId = courseId;
        CourseName = courseName;
        GymId = gymId;
    }

    public long CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public long GymId { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual Gym Gym { get; set; } = null!;

    public virtual ICollection<ContractsTerm> ContractTerms { get; set; } = new List<ContractsTerm>();
}
