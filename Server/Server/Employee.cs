using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PersonnelNumber { get; set; }
        public string Chief { get; set; }
        public string Department { get; set; }
    }

    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Staff { get; set; }

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
