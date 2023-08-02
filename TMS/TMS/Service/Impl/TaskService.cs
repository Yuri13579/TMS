using Microsoft.Extensions.Caching.Memory;
using Data.Model;
using Data.Model.DTO;
using TaskStatus = Data.Model.TaskStatus;
using Data.Repo;

namespace TMS.Service.Impl.Impl
{
    public class TaskService : ITaskService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IServiceBusSender _serviceBusSender;
        private readonly ITaskRepository _taskRepository;

        public TaskService(
            IMemoryCache memoryCache,
            IServiceBusSender serviceBusSender,
            ITaskRepository taskRepository
            )
        {
            _memoryCache = memoryCache;
            _serviceBusSender = serviceBusSender;
            _taskRepository = taskRepository;
        }

        public async Task< List<Data.Model.Task>> GetAllTasksAync()
        {
            var t = await _taskRepository.GetAllTasks();
            return GetCachedTasks();
        }

        public async Task<Data.Model.Task> AddTaskAync(Data.Model.Task task)
        {
            List<Data.Model.Task> tasks = GetCachedTasks();
            task.TaskID = tasks.Count + 1; // Auto-generate TaskID for simplicity
            tasks.Add(task);
            UpdateCachedTasks(tasks);
            await _serviceBusSender.Send(task);
            await _taskRepository.AddTask(task);
            return task;
        }

        public Data.Model.Task UpdateTaskStatus(UpdateTaskDTO updateTaskDTO)
        {
            List<Data.Model.Task> tasks = GetCachedTasks();
            List<TaskUpdate> taskUpdates = GetCachedTaskUpdates();
            Data.Model.Task taskToUpdate = tasks.FirstOrDefault(t => t.TaskID == updateTaskDTO.TaskId);
            if (taskToUpdate != null)
            {
                taskToUpdate.Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), updateTaskDTO.NewStatus); 
                UpdateCachedTasks(tasks);
                UpdateCachedTaskUpdates(taskUpdates);
            }
            return taskToUpdate;
        }

        private List<Data.Model.Task> GetCachedTasks()
        {
            if (!_memoryCache.TryGetValue(AppConst.CacheKeyTask, out List<Data.Model.Task> tasks))
            {
                tasks = new List<Data.Model.Task>();
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

        private void UpdateCachedTasks(List<Data.Model.Task> tasks)
        {
            _memoryCache.Set(AppConst.CacheKeyTask, tasks, TimeSpan.FromMinutes(60)); // Cache for 30 minutes
        }
        private void UpdateCachedTaskUpdates(List<TaskUpdate> taskUpdates)
        {
            _memoryCache.Set(AppConst.CacheKeyTaskUpdate, taskUpdates, TimeSpan.FromMinutes(60)); // Cache for 30 minutes
        }

    }
}
