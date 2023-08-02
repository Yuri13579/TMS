using Microsoft.Extensions.Caching.Memory;
using TMS.Model;
using TMS.Model.DTO;
using TaskStatus = TMS.Model.TaskStatus;

namespace TMS.Service.Impl.Impl
{
    public class TaskService : ITaskService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IServiceBusSender _serviceBusSender;

        public TaskService(
            IMemoryCache memoryCache,
            IServiceBusSender serviceBusSender
            )
        {
            _memoryCache = memoryCache;
            _serviceBusSender = serviceBusSender;
        }

        public List<Model.Task> GetAllTasks()
        {
            return GetCachedTasks();
        }

        public async Task<Model.Task> AddTask(Model.Task task)
        {
            List<Model.Task> tasks = GetCachedTasks();
            task.TaskID = tasks.Count + 1; // Auto-generate TaskID for simplicity
            tasks.Add(task);
            UpdateCachedTasks(tasks);
            await _serviceBusSender.Send(task);
            return task;
        }

        public Model.Task UpdateTaskStatus(UpdateTaskDTO updateTaskDTO)
        {
            List<Model.Task> tasks = GetCachedTasks();
            List<TaskUpdate> taskUpdates = GetCachedTaskUpdates();
            Model.Task taskToUpdate = tasks.FirstOrDefault(t => t.TaskID == updateTaskDTO.TaskId);
            if (taskToUpdate != null)
            {
                taskToUpdate.Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), updateTaskDTO.NewStatus); 
                UpdateCachedTasks(tasks);
                UpdateCachedTaskUpdates(taskUpdates);
            }
            return taskToUpdate;
        }

        private List<Model.Task> GetCachedTasks()
        {
            if (!_memoryCache.TryGetValue(AppConst.CacheKeyTask, out List<Model.Task> tasks))
            {
                tasks = new List<Model.Task>();
                _memoryCache.Set(AppConst.CacheKeyTask, tasks, TimeSpan.FromMinutes(60)); // Cache for 30 minutes
            }
            return tasks;
        }

        private List<TaskUpdate> GetCachedTaskUpdates()
        {
        if (!_memoryCache.TryGetValue(AppConst.CacheKeyTask, out List<TaskUpdate> taskUpdates))
        {
             taskUpdates = new List<TaskUpdate>();
             _memoryCache.Set(AppConst.CacheKeyTaskUpdate, taskUpdates, TimeSpan.FromMinutes(60)); // Cache for 30 minutes
        }
            return taskUpdates;
        }

        private void UpdateCachedTasks(List<Model.Task> tasks)
        {
            _memoryCache.Set(AppConst.CacheKeyTask, tasks, TimeSpan.FromMinutes(60)); // Cache for 30 minutes
        }
        private void UpdateCachedTaskUpdates(List<TaskUpdate> taskUpdates)
        {
            _memoryCache.Set(AppConst.CacheKeyTaskUpdate, taskUpdates, TimeSpan.FromMinutes(60)); // Cache for 30 minutes
        }

    }
}
