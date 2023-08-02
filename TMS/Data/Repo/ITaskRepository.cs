namespace Data.Repo
{
    public interface ITaskRepository
    {
        Task<Model.Task> AddTask(Model.Task task);
        Task<Model.Task> UpdateTask(Model.Task task);
        Task<bool> DeleteTask(int taskId);
        Task<Model.Task> GetTask(int taskId);
        Task<List<Model.Task>> GetAllTasks();
    }

}
