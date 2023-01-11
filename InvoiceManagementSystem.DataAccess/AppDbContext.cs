using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace InvoiceManagementSystem.DataAccess
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=InvoiceManagement;User Id=postgres;Password=postgres;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>().HasKey(x => x.Id);
            modelBuilder.Entity<Apartment>().Property(x => x.Id).IsRequired(true);

            modelBuilder.Entity<Suite>().HasKey(x => x.Id);
            modelBuilder.Entity<Suite>().Property(x => x.Id).IsRequired(true);

            modelBuilder.Entity<Dues>().HasKey(x => x.Id);
            modelBuilder.Entity<Dues>().Property(x => x.Id).IsRequired(true);

            //modelBuilder.Entity<Suite>().HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
            //modelBuilder.Entity<Suite>().HasOne<Apartment>().WithMany().HasForeignKey(x => x.ApartmentId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Suite> Suites { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Management> Managements { get; set; }
        public DbSet<Dues> Dues { get; set; }
        public DbSet<BillType> BillTypes { get; set; }
        public DbSet<UserAssign> UserAssign { get; set; }
    }
}
