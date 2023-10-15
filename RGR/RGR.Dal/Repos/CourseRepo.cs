﻿using Npgsql;
using RGR.Dal.Models.Entities;
using RGR.Dal.Repos.BaseRepo;

namespace RGR.Dal.Repos
{
    public class CourseRepo : BaseRepo<Class>
    {
        public CourseRepo(NpgsqlConnection connection) : base(connection) { }
    }
}

