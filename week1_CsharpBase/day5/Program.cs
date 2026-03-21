class Program
{
    public static void Main(string[] args)
    {
        Employee emp = new Employee("Emilia", "Amazon", 1999);
        emp.Print();
        emp.Work();
        Console.WriteLine();
        
        Developer devemp = new Developer("Davidzhan", "Microsoft", "Developer",2009, DeveloperPost.Senior);
        devemp.Print();
        devemp.Work();
        Console.WriteLine();

        Manager manager = new Manager("Alisa", "Apple","Manager", 2004, 28);
        manager.Print();
        manager.Work();

    }
}