using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreWebApplicationDBFirst.Models
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions options)
    : base(options)
{ }
        public virtual DbSet<Employee> Employee { get; set; }

////        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
////        {
////            if (!optionsBuilder.IsConfigured)
////            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
////                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EmployeeDB;Trusted_Connection=True;");
////            }
////        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}
