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

        public DbSet<UserLog> UserLogs { get; set; }


        public DbSet<HotelDepartment>  HotelDepartments { get; set; }

        public DbSet<EmployeeUser> EmployeeUsers { get; set; }

        public DbSet<Rate> Rates { get; set; }

        public DbSet<FieldOfRating> FieldOfRatings { get; set; }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }


    }
}
