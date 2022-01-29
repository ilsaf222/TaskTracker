namespace TaskTracker.Models.Objective
{
    public class ListObjectiveViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public int Priority { get; set; }
    }
}
