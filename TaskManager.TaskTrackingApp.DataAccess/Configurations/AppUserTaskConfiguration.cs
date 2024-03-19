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
    public class AppUserTaskConfiguration : IEntityTypeConfiguration<AppUserTask>
    {
        public void Configure(EntityTypeBuilder<AppUserTask> builder)
        {
            builder.HasIndex(x => new { x.AppUserId, x.AppTaskId }).IsUnique();
            builder.Property(x => x.AppTaskId).IsRequired();
            builder.Property(x => x.AppUserId).IsRequired();
            builder.Property(x => x.TaskStatusId).IsRequired();
            builder.Property(x => x.TaskEndDate).IsRequired();
            builder.HasOne(x => x.AppTask).WithOne(x => x.AppUserTask);
            builder.HasOne(x => x.TaskStatus).WithMany(x => x.AppUserTasks).HasForeignKey(x => x.TaskStatusId);
            builder.Property(x => x.CompleteDocumentDefination).IsRequired(false);
            builder.Property(x => x.DocumentPath).IsRequired(false);
            builder.Property(x => x.CompletedTaskDate).HasColumnType("smalldatetime");
        }
    }
}
