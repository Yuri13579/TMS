using TMS.Model.DTO;
using TaskStatus = TMS.Model.TaskStatus;
namespace TMS.Service
{
    public interface ITaskService
    {
        public List<Model.Task> GetAllTasks();
        public Model.Task AddTask(Model.Task task);
        public Model.Task UpdateTaskStatus(UpdateTaskDTO updateTaskDT);

    }
}
