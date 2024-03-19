using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManager.TaskTrackingApp.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TaskManager.TaskTrackingApp.UI.Models
{
    public class AppTaskCreateModel 
    {
        [NotNull]
        public string Title { get; set; }
        
        [NotNull]
        public string Defination { get; set; }
        
        [NotNull]
        public int PriortryId { get; set; }

        public SelectList PriortrySelectList { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public bool IsActive { get; set; } = true;

        [NotNull]
        public int AppUserId { get; set; }

        public SelectList UserList { get; set; }

    }
}
