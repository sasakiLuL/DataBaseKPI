using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace RGR.Dal.Models;

public partial class Class
{
    public Class()
    {

    }

    public Class(int maxParticipants, NpgsqlRange<DateTime> duration, long courseId)
    {
        MaxParticipants = maxParticipants;
        Duration = duration;
        CourseId = courseId;
    }

    public long ClassId { get; set; }

    public int MaxParticipants { get; set; }

    public NpgsqlRange<DateTime> Duration { get; set; }

    public long CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Coach> Coaches { get; set; } = new List<Coach>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
