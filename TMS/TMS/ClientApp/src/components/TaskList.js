import React from "react";

const TaskList = ({ tasks, onUpdateTaskStatus }) => {
    const handleStatusChange = (taskId, event) => {
        const newStatus = event.target.value;
        onUpdateTaskStatus(taskId, newStatus);
      };
  return (
    <div>
      <h2>Task List</h2>
      <ul>
        {tasks.map((task) => (
          <li key={task.taskID}>
             <strong>Task Name:</strong> {task.taskName}
            <br />
            <strong>Description:</strong> {task.description}
            <br />
            <strong>Status:</strong>
            <select value={task.status} onChange={(e) => handleStatusChange(task.taskID, e)}>
              <option value="NotStarted">Not Started</option>
              <option value="InProgress">In Progress</option>
              <option value="Completed">Completed</option>
            </select>
            <br />
            <strong>Assigned To:</strong> {task.assignedTo}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default TaskList;
