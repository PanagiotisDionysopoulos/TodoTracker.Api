namespace TodoTracker.Api.Models
{
    public class CreateTodoRequest
    {
        public string Title { get; set; } = string.Empty;
    }

    public class UpdateTodoRequest
    {
        public bool IsCompleted { get; set; }
    }
}
