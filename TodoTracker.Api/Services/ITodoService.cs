using TodoTracker.Api.Models;

namespace TodoTracker.Api.Services
{
    public interface ITodoService
    {
        List <TodoItem> GetAll ();
        TodoItem? GetById (int id);
        TodoItem Create(string title);
        bool Update (int id, bool isComplete);
        bool Delete (int id);
    }
}
