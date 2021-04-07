using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentCarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;Database=CarDB;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<MemberOperationClaim> MemberOperationClaims { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<User>().HasKey(x => x.Id);

            modelBuilder.Entity<User>().Property(x => x.Id).HasColumnName("ID");
            modelBuilder.Entity<User>().Property(x => x.FirstName).HasColumnName("FIRSTNAME");
            modelBuilder.Entity<User>().Property(x => x.LastName).HasColumnName("LASTNAME");
            modelBuilder.Entity<User>().Property(x => x.Email).HasColumnName("EMAIL");
            modelBuilder.Entity<User>().Property(x => x.Password).HasColumnName("_PASSWORD");
        }
    }
}
