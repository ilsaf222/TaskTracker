using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Domain.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Description { get; set; }

        public ProjectStatus Status {get;set;}

        public int Priority { get; set; }

        public List<Objective> Objectives { get; set; }

    }
}
