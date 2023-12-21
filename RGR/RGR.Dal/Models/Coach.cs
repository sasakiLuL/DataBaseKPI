using System;
using System.Collections.Generic;

namespace RGR.Dal.Models;

public partial class Coach
{
    public Coach()
    {

    }

    public Coach(long coachId, string firstName, string lastName, DateOnly employmentDate, string? description, long gymId)
    {
        CoachId = coachId;
        FirstName = firstName;
        LastName = lastName;
        EmploymentDate = employmentDate;
        Description = description;
        GymId = gymId;
    }

    public long CoachId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly EmploymentDate { get; set; }

    public string? Description { get; set; }

    public long GymId { get; set; }

    public virtual Gym Gym { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
