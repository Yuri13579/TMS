import React, { useState } from "react";

const TaskForm = ({ onAddTask, onUpdateTaskStatus }) => {
  const [taskName, setTaskName] = useState("");
  const [description, setDescription] = useState("");
  const [assignedTo, setAssignedTo] = useState("");

  const handleAddTask = () => {
    // Validation can be added here if needed
    const newTask = {
      taskName,
      description,
      assignedTo,
    };
    onAddTask(newTask);
    setTaskName("");
    setDescription("");
    setAssignedTo("");
  };

  const handleStatusChange = async (taskId, newStatus) => {
    try {
      await onUpdateTaskStatus(taskId, newStatus);
    } catch (error) {
      console.error("Error updating task status:", error);
    }
  };

  return (
    <div>
      <h2>Add New Task</h2>
      <label>Task Name:</label>
      <input
        type="text"
        value={taskName}
        onChange={(e) => setTaskName(e.target.value)}
      />
      <label>Description:</label>
      <input
        type="text"
        value={description}
        onChange={(e) => setDescription(e.target.value)}
      />
      <label>Assigned To:</label>
      <input
        type="text"
        value={assignedTo}
        onChange={(e) => setAssignedTo(e.target.value)}
      />
      <button onClick={handleAddTask}>Add Task</button>
      
    </div>
  );
};

export default TaskForm;