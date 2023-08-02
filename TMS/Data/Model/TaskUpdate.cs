using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    public class TaskUpdate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TaskUpdateID { get; set; }
        public int TaskID { get; set; }
        public TaskStatus NewStatus { get; set; }
        public string UpdatedBy { get; set; }

            public TaskUpdate(int taskUpdateID, int taskID, TaskStatus newStatus, string updatedBy)
            {
                TaskUpdateID = taskUpdateID;
                TaskID = taskID;
                NewStatus = newStatus;
                UpdatedBy = updatedBy;
            }
        }
}
