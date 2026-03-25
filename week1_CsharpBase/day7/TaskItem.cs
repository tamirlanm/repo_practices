
class TaskItem
{
    public int Id {get; set;}
    public string Title {get; set;}
    public string Description{ get; set;}
    public bool IsDone {get; set;}

    public TaskItem(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
        IsDone = false;
    }

}