using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoTracker.Api.Models;
using TodoTracker.Api.Services;

namespace TodoTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = _todoService.GetAll();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _todoService.GetById(id);
            if (todo == null)
            {
                return NotFound(new { message = $"Todo with ID {id} not found." }); // Επιστρέφει 404 Not Found
            }
            return Ok(todo);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTodoRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return BadRequest();
            }
            var createdTodo = _todoService.Create(request.Title);

            return CreatedAtAction(nameof(GetById), new { id = createdTodo.Id }, createdTodo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateTodoRequest request)
        {
            var isUpdated = _todoService.Update(id, request.IsCompleted);
            if (!isUpdated)
            {
                return NotFound(new { message = $"Todo with ID {id} not found." });
            }
            return NoContent(); // Επιστρέφει 204 No Content
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var isDeleted = _todoService.Delete(id);
            if (!isDeleted)
            {
                return NotFound(new { message = $"Todo with ID {id} not found." });
            }
            return NoContent();
        }
    }
}
