using TaskTracker.Domain.Enums;

namespace TaskTracker.Models.Project
{
    public class CreateProjectViewModel
    {
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Description { get; set; }

        public ProjectStatus Status { get; set; }

        public int Priority { get; set; }
    }
}
