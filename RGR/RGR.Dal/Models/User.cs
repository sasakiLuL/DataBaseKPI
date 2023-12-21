using System;
using System.Collections.Generic;

namespace RGR.Dal.Models;

public partial class User
{
    public User()
    {

    }

    public User(long userId, string firstName, string lastName, int sex, DateOnly dateOfBirth, string? phone, string address, string email)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Sex = sex;
        DateOfBirth = dateOfBirth;
        Phone = phone;
        Address = address;
        Email = email;
    }

    public long UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Sex { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string? Phone { get; set; }

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Gym> Gyms { get; set; } = new List<Gym>();
}
