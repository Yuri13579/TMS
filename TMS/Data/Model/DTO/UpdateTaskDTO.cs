namespace Data.Model.DTO
{
    public class UpdateTaskDTO
    {
        public int TaskId { get; set; }
        public string NewStatus { get; set; }

        public UpdateTaskDTO(
            int taskId,
            string newStatus)
        {
            TaskId = taskId;
            NewStatus = newStatus;
        }
    }
}
