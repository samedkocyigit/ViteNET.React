using Microsoft.AspNetCore.Mvc;
using ViteNET.React.Domain.Models.DTOs;

namespace ViteNET.React.Pages.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;
        private readonly IUserService _userService;

        public TasksController(ITasksService tasksService, IUserService userService)
        {
            _tasksService = tasksService;
            _userService = userService;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetAllTasks()
        {
            var tasks = await _tasksService.GetAllTasksAsync();
            return Ok(tasks);
        }

        // GET: api/tasks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTaskById(int id)
        {
            var task = await _tasksService.GetTaskByIdAsync(id);
            return Ok(task);
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskDto>> AddTask(CreateTaskDto createTaskDto)
        {
            var taskDto = await _tasksService.AddTaskAsync(createTaskDto);
            return CreatedAtAction(nameof(GetTaskById), new { id = taskDto.Id }, taskDto);
        }

        // PUT: api/tasks/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<TaskDto>> UpdateTask(int id, UpdateTaskDto updateTaskDto)
        {
            var existingTask = await _tasksService.GetTaskByIdAsync(id);
            if (existingTask == null)
            {
                return NotFound();
            }

            var updatedTask = await _tasksService.UpdateTaskAsync(updateTaskDto);
            return Ok(updatedTask);
        }

        // DELETE: api/tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _tasksService.DeleteTaskAsync(id);
            return NoContent();
        }

        // GET: api/tasks/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasksByUserId(int userId)
        {
            var tasks = await _tasksService.GetTasksByUserIdAsync(userId);
            return Ok(tasks);
        }
    }
}