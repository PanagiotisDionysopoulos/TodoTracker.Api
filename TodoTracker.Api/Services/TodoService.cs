using TodoTracker.Api.Models;

namespace TodoTracker.Api.Services
{
    public class TodoService : ITodoService
    {
        private readonly List<TodoItem> _todos = new();
        private int _nextId = 1;

        public List<TodoItem> GetAll() {  return _todos; }
        public TodoItem GetById(int id)
        {
            return _todos.FirstOrDefault(t => t.Id == id);
        }
        public TodoItem Create(string title) {
            var newTodo = new TodoItem
            {
                Id = _nextId++,
                Title = title,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };

            _todos.Add(newTodo);
            return newTodo;
        }
        public bool Update(int id, bool isCompleted)
        {
            var todo = GetById(id);
            if (todo == null)
            {
                return false;
            }

            todo.IsCompleted = isCompleted;
            return true;
        }
        public bool Delete(int id) {
            var todo = GetById(id);
            if (todo == null)
            {
                return false;
            }

            _todos.Remove(todo);
            return true;
        }

    }
}
