namespace TMS.Model
{
    public class TaskUpdate
{
    public int TaskID { get; set; }
    public TaskStatus NewStatus { get; set; }
    public string UpdatedBy { get; set; }

    public TaskUpdate(int taskID, TaskStatus newStatus, string updatedBy)
    {
        TaskID = taskID;
        NewStatus = newStatus;
        UpdatedBy = updatedBy;
    }
}
}
