using BugTracker.Domain.Entities;
using BugTracker.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Bug> Bugs { get; set; }
        public DbSet<BugHistory> BugHistory { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            InitStubData(modelBuilder);
        }

        private void InitStubData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new List<User>()
            {
                new User {Id = 1, Name = "Alex", LastName = "Rock", Login = "Alex55", Password = "321" },
                new User {Id = 2, Name = "Nancy", LastName = "Li", Login = "Li77", Password = "123" }
            });

            modelBuilder.Entity<Bug>().HasData(new List<Bug>()
            {
                new Bug {Id = 1, Title = "Back Error", Description = "Server doesn't answer", Urgency = BugUrgency.High, Status = BugStatus.New, Criticality = BugCriticality.Alarm, UserId = 1},
                new Bug {Id = 2, Title = "Front Error", Description = "UI spelling mistake", Urgency = BugUrgency.Low, Status = BugStatus.New, Criticality = BugCriticality.NonCritical, UserId = 2}
            });

            modelBuilder.Entity<BugHistory>().HasData(new List<BugHistory>()
            {
                new BugHistory {Id = 1, Action = BugAction.Input, BugId = 1 },
                new BugHistory {Id = 2, Action = BugAction.Input, BugId = 2 }
            });
        }
    }
}
