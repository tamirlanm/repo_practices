
class Repository<T>
{
    protected List<T> list = new List<T>();
    public void Add(T item)
    {
        list.Add(item);
    }
    public void Show()
    {
        foreach(T item in list)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();
    }
    public List<T> GetAll()
    {
        return list;
    }
    public void Remove(T item)
    {
        list.Remove(item);
    }
}