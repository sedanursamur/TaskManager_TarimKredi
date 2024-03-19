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
    public class PriortryConfiguration : IEntityTypeConfiguration<Priortry>
    {
        public void Configure(EntityTypeBuilder<Priortry> builder)
        {
            builder.Property(x => x.Defination).IsRequired().HasMaxLength(100);
        }
    }
}
