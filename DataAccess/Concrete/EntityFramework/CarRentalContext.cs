using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarRentalContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocaldb;Database=CarRental;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);

            modelBuilder.Entity<OperationClaim>().ToTable("OperationClaims");
            modelBuilder.Entity<OperationClaim>().Property(o => o.Id).HasColumnName("Id");
            modelBuilder.Entity<OperationClaim>().Property(o => o.Name).HasColumnName("Name");

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().Property(o => o.Id).HasColumnName("UserId");
            modelBuilder.Entity<User>().Property(o => o.FirstName).HasColumnName("FirstName");
            modelBuilder.Entity<User>().Property(o => o.LastName).HasColumnName("LastName");
            modelBuilder.Entity<User>().Property(o => o.Email).HasColumnName("Email");
            modelBuilder.Entity<User>().Property(o => o.Status).HasColumnName("Status");
            modelBuilder.Entity<User>().Property(o => o.PasswordHash).HasColumnName("PasswordHash");
            modelBuilder.Entity<User>().Property(o => o.PasswordSalt).HasColumnName("PasswordSalt");
        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public  DbSet<Rental> Rentals { get; set; }
        public DbSet<Customer> Customerss { get; set; }
        public DbSet<Image> CarImages { get; set; }
      


    }
}
