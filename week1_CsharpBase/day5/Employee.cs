
class Employee
{
    public string Name {get; set;}
    public string Company{get;set;} = "Undefined";
    public int YearFrom {get;set;}
    public string TypeEmployee {get; set;}


    public Employee(string name, string company, int yearFrom)
    {
        Name = name;
        Company = company;
        YearFrom = yearFrom;

    }

    public virtual void Work()
    {
        Console.WriteLine($"Employee is working.");
    }
    public void Print() => Console.WriteLine($"Person Name: {Name}\nCompany name where he is working: {Company}\nYear from {Name} works: {YearFrom}");
}