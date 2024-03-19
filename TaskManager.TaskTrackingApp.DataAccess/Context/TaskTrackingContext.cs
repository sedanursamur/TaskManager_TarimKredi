using Microsoft.EntityFrameworkCore;
using TaskManager.TaskTrackingApp.DataAccess.Configurations;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.DataAccess.Context
{
    public class TaskTrackingContext : DbContext
    {

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }

        public DbSet<AppUserRole> AppUserRoles { get; set; }

        public DbSet<Priortry> Priortries { get; set; }

        public DbSet<AppTask> AppTasks { get; set; }

        public DbSet<AppUserTask> AppUserTasks { get; set; }

        public DbSet<Degree> Degrees { get; set; }

        public DbSet<AppTaskStatus> TaskStatuses { get; set; }

        public TaskTrackingContext()
        {

        }     
        public TaskTrackingContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppTaskConfiguration());
            modelBuilder.ApplyConfiguration(new AppTaskStatusConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserTaskConfiguration());
            modelBuilder.ApplyConfiguration(new DegreeConfiguration());
            modelBuilder.ApplyConfiguration(new PriortryConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TaskManager_TarimKredi;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}