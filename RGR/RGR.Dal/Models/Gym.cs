using System;
using System.Collections.Generic;

namespace RGR.Dal.Models;

public partial class Gym
{
    public Gym()
    {

    }

    public Gym(long gymId, string gymName, string address, string? homePage, string phone, string? email)
    {
        GymId = gymId;
        GymName = gymName;
        Address = address;
        HomePage = homePage;
        Phone = phone;
        Email = email;
    }

    public long GymId { get; set; }

    public string GymName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? HomePage { get; set; }

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public virtual ICollection<Coach> Coaches { get; set; } = new List<Coach>();

    public virtual ICollection<ContractsTerm> ContractsTerms { get; set; } = new List<ContractsTerm>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
