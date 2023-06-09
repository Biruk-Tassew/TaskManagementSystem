namespace TM.Application.Features.Tasks.DTOs
{
    public interface ITasksDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}