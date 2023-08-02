using Data.Model.DTO;
using TaskStatus = Data.Model.TaskStatus;
namespace TMS.Service.Impl
{
    public interface ITaskService
    {
        public Task<List<Data.Model.Task>> GetAllTasksAync();
        public Task<Data.Model.Task> AddTaskAync(Data.Model.Task task);
        public Data.Model.Task UpdateTaskStatus(UpdateTaskDTO updateTaskDT);

    }
}
