using kudvenkitPractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Transactions;

namespace kudvenkitPractice.DAL
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options) 
            :base(options)
        {
            
        }
        public DbSet<Employee> Employees{ get; set; }
        public override EntityEntry Add(object entity)
        {
            return base.Add(entity);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Umair",
                    Department = DepartmentEnums.ComputerScience,
                    Gender = GenderEnums.Male,
                    Email = "umairtahir@gmail.com",
                    PhotoPath = ""

                },
                new Employee
                {
                    Id = 2,
                    Name = "Ammara",
                    Department = DepartmentEnums.ComputerScience,
                    Gender = GenderEnums.Female,
                    Email = "Ammara.tahir@gmail.com",
                    PhotoPath = ""
                }, 
                new Employee
                {
                    Id = 3,
                    Name = "Uzair",
                    Department = DepartmentEnums.ComputerScience,
                    Gender = GenderEnums.Male,
                    Email = "Uzair.tahir@gmail.com",
                    PhotoPath = ""

                },
                new Employee
                {
                    Id = 4,
                    Name = "Ayesha",
                    Department = DepartmentEnums.ComputerScience,
                    Gender = GenderEnums.Female,
                    Email = "Ayesha.tahir@gmail.com",
                    PhotoPath = ""
                }
                );

        }
    }
     
}
