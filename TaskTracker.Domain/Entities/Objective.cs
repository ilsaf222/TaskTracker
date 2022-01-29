using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Domain.Entities
{
    public class Objective //Task(задача)
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public int Priority { get; set; }

        public int ProjectId { get; set; }

        //public Project Project { get; set; }

    }
}
