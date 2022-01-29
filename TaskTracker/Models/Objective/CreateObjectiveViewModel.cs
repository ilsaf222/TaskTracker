namespace TaskTracker.Models.Objective
{
    public class CreateObjectiveViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public int Priority { get; set; }

        public int ProjectId { get; set; }

    }
}
