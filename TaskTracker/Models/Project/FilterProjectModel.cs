using TaskTracker.Domain.Enums;

namespace TaskTracker.Models.Project
{
    public class FilterProjectModel
    {
        public string? Name { get; set; }

        public bool? StartTime { get; set; }

        public bool? EndTime { get; set; }

        public ProjectStatus? Status { get; set; }

        public int? Priority { get; set; }

        public string? SearchText { get; set; }

        public bool NullCheck()
        {
            if(Name == null && StartTime == null && EndTime == null && Status == null && Priority == null && SearchText == null)
            {
                return true;
            }

            return false;
        }
    }
}
