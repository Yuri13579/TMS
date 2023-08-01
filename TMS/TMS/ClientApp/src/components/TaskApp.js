import React, { useEffect, useState } from "react";
import TaskForm from "./TaskForm";
import TaskList from "./TaskList";

const TaskApp = () => {
  const [tasks, setTasks] = useState([]);

  useEffect(() => {
    fetchTasks();
  }, []);

  const fetchTasks = async () => {
    try {
        const response = await fetch('task');
        const data = await response.json();
      setTasks(data);
    } catch (error) {
      console.error("Error fetching tasks:", error);
    }
  };

  const handleAddTask = async (newTask) => {
    try {
        const response = await fetch('task/add', {
            method: "POST", 
            mode: "cors", 
            cache: "no-cache", 
            credentials: "same-origin", 
            headers: {
              "Content-Type": "application/json",
            },
            redirect: "follow", 
            referrerPolicy: "no-referrer", 
            body: JSON.stringify(newTask), 
          });
      const data =  response.json(); 
      console.log(data);
      debugger;
      fetchTasks();
    } catch (error) {
      console.error("Error adding task:", error);
    }
  };

  const handleUpdateTaskStatus = async (taskId, newStatus) => {
    try {
        const body = {
            'taskId':taskId,
            'newStatus':newStatus
        };
        debugger;
        const response = await fetch('task/update', {
            method: "PUT", 
            mode: "cors", 
            cache: "no-cache", 
            credentials: "same-origin", 
            headers: {
              "Content-Type": "application/json",
            },
            redirect: "follow", 
            referrerPolicy: "no-referrer", 
            body: JSON.stringify(body), 
          });
          debugger;
        const data =  response.json(); 
      console.log(data);
      console.log("Task status updated:", taskId, newStatus);
      fetchTasks();
    } catch (error) {
      console.error("Error updating task status:", error);
    }
  };

  return (
    <div>
      <TaskForm onAddTask={handleAddTask} onUpdateTaskStatus={handleUpdateTaskStatus}/>
      <TaskList tasks={tasks} onUpdateTaskStatus={handleUpdateTaskStatus}/>
    </div>
  );
};

export default TaskApp;
