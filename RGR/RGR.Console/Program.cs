using RGR.Dal.Entities;
using RGR.Dal.ORM;

DbSet<User> test = new DbSet<User>();

test.Where(e => e.FirstName == "LOL");