﻿using Microsoft.EntityFrameworkCore;
using Employee_Management_System.Models;
using System.Collections.Generic;
namespace Employee_Management_System
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
