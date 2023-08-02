using Microsoft.AspNetCore.Mvc;
using Data.Model.DTO;
using TMS.Service.Impl;
using TaskStatus = Data.Model.TaskStatus;

namespace TMS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // POST: api/tasks/add
        [HttpPost("add")]
        public async Task<IActionResult> AddTask(Data.Model.Task task)
        {
            await _taskService.AddTaskAync(task);
            return Ok("Task added successfully!");
        }

        // PUT: api/tasks/update/{taskId}/{newStatus}
        [HttpPut("update")]
        public IActionResult UpdateTaskStatus(UpdateTaskDTO updateTaskDTO)
        {
     
            Data.Model.Task updatedTask = _taskService.UpdateTaskStatus(updateTaskDTO);
            if (updatedTask == null)
            {
                return NotFound("Task not found.");
            }
            return Ok("Task status updated successfully!");
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            List<Data.Model.Task> tasks = await _taskService.GetAllTasksAync();
            return Ok(tasks);
        }
    }
}
