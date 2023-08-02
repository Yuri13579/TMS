using TMS.Model.DTO;
using TaskStatus = TMS.Model.TaskStatus;
namespace TMS.Service.Impl
{
    public interface ITaskService
    {
        public List<Model.Task> GetAllTasks();
        public Task<Model.Task> AddTask(Model.Task task);
        public Model.Task UpdateTaskStatus(UpdateTaskDTO updateTaskDT);

    }
}
