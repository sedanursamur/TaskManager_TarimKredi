using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.TaskTrackingApp.DataAccess.Configurations
{
    public class AppTaskConfiguration : IEntityTypeConfiguration<AppTask>
    {
        public void Configure(EntityTypeBuilder<AppTask> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Defination).IsRequired().HasMaxLength(500);
            builder.Property(x => x.EndDateTime).IsRequired();
            builder.Property(x => x.PriortryId).IsRequired();
            builder.Property(x => x.AppUserId).IsRequired();
            builder.Property(x => x.CreatedTime).HasDefaultValueSql("getdate()");
            builder.Property(x => x.IsActive).IsRequired();

            builder.HasOne(x => x.Priortry).WithMany(x => x.AppTasks).HasForeignKey(x => x.PriortryId);
        }
    }
}
