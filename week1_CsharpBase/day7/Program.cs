TaskManager taskmanager = new TaskManager();

taskmanager.AddTask(1, "Learn C#", "This task about to learn C# and .NET concepts. ");
taskmanager.AddTask(2, "Finish project", "We need to finish the project from subject Golang Backend Appliaction.");
taskmanager.AddTask(3, "Make a prototype of gcd", "I need to make some prototype of game concept using some AI CLI and something is beginning with S");
Console.WriteLine();
taskmanager.ShowAllTasks();
taskmanager.ShowHistory();
taskmanager.CompleteTask(2);
taskmanager.ShowHistory();
TaskItem? findTask = taskmanager.FindTask(2);
if(findTask != null)
{
    Console.WriteLine($"Founded task Id: {findTask.Id} and Title: {findTask.Title}\n{findTask.Description}\n");
}
taskmanager.ShowAllTasks();
