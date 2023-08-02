using Microsoft.AspNetCore.Mvc;
using TMS.Model.DTO;
using TMS.Service.Impl;
using TaskStatus = TMS.Model.TaskStatus;

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
        public IActionResult AddTask(Model.Task task)
        {
            _taskService.AddTask(task);
            return Ok("Task added successfully!");
        }

        // PUT: api/tasks/update/{taskId}/{newStatus}
        [HttpPut("update")]
        public IActionResult UpdateTaskStatus(UpdateTaskDTO updateTaskDTO)
        {
     
            Model.Task updatedTask = _taskService.UpdateTaskStatus(updateTaskDTO);
            if (updatedTask == null)
            {
                return NotFound("Task not found.");
            }
            return Ok("Task status updated successfully!");
        }

        // GET: api/tasks
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            List<Model.Task> tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }
    }
}
