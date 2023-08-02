using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Task
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int TaskID { get; set; }
    public string TaskName { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; }
    public string AssignedTo { get; set; }

    public Task(
        int taskID,
        string taskName,
        string description,
        TaskStatus status,
        string? assignedTo = null)
    {
        TaskID = taskID;
        TaskName = taskName;
        Description = description;
        Status = status;
        AssignedTo = assignedTo;
    }
}
