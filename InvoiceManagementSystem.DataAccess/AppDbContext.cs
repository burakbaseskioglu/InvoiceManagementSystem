﻿using InvoiceManagementSystem.Entity.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.DataAccess
{
    public class AppDbContext : DbContext
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

            //modelBuilder.Entity<Suite>().HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Suite> Suites { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Management> Managements { get; set; }
        public DbSet<Dues> Dues { get; set; }
    }
}
