# TMS
Title: Task Management System with Service Bus Integration
Challenge Description:
Create a console or web api application (your choice) using C# and .NET that simulates a Task
Management System with integration to a service bus (e.g., Azure Service Bus or RabbitMQ).
The application should allow users to perform the following tasks:
1. Add new tasks
2. Update task status
3. Show the list of tasks and their status
Requirements:
● Create a Task class with the following properties:
○ TaskID (int)
○ TaskName (string)
○ Description (string)
○ Status ( NotStarted, InProgress, Completed)
○ AssignedTo (string, optional)
● Functionalities for the following actions (API or through user input in a console app):
○ Add a new task
○ Update task status
○ Display a list of tasks and their details
● Implement a TaskUpdate class with the following properties:
○ TaskID (int)
○ NewStatus (NotStarted, InProgress, Completed)
○ UpdatedBy (string)
● Implement a ServiceBusHandler class to manage sending and receiving messages to
and from the service bus:
○ SendMessage: Serialize the TaskUpdate object and send it as a message to the
service bus
○ ReceiveMessage: Listen for messages on the service bus, deserialize the
received message to a TaskUpdate object, and update the corresponding task in
the system
○ When a task status is updated, send the TaskUpdate object to the service bus
Bonus Points:
● Storing task object in SQL Server through EF core
● Use dependency injection
● Implement exception handling and retry logic for service bus communication
● Add unit tests for the ServiceBusHandler class and the Task Management System
functionalities
Note: The candidate is encouraged to use online resources and documentation, but they should
complete the challenge independently and without any external help.
