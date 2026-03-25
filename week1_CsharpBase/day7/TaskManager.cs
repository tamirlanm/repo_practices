class TaskManager
{
    List<TaskItem> taskItems = new List<TaskItem>();
    Dictionary<int, TaskItem> dict = new Dictionary<int, TaskItem>();
    Stack<string> stackHistory = new Stack<string>();

    public void AddTask(int id, string title, string description)
    {
        TaskItem task = new TaskItem(id, title, description);   
        taskItems.Add(task);
        dict.Add(id, task);
        stackHistory.Push($"Added a new task. Id: {id}. Title: {title}");
    }
    
    public TaskItem? FindTask(int id)
    {
        if (dict.ContainsKey(id))
        {
            return dict[id];
        }
        else
        {
            return null;
        }
    }

    public void ShowAllTasks()
    {
        foreach(var task in taskItems)
        {
            string status = task.IsDone ? "Done" : "Not Done";
            Console.WriteLine($"Task Id: {task.Id}\nTask Title: {task.Title}\nTask Description: {task.Description}\nTask is {status}");
        }
    }

    public void CompleteTask(int id)
    {
        if (dict.ContainsKey(id))
        {
            dict[id].IsDone = true;
            stackHistory.Push($"Completed task. Id: {id}, Title: {dict[id].Title}, Description: {dict[id].Description}");
        }
    }
    public void ShowHistory()
    {
        foreach(var history in stackHistory)
        {
            Console.WriteLine(history);
        }
    }
}
