using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentDataLayer
{
    public class MyContext:DbContext
    {

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AcceptedEmployee> AcceptedEmployees { get; set; }


        public DbSet<Permission> Permissions { get; set; }

        public DbSet<UsersPermission> UsersPermissions { get; set; }

    }
}
