class Manager : Employee
{
    public int WarningDid {get; set;}
    public Manager(string name, string company, string typeEmp, int yearFrom ,int warningDid) : base(name, company, yearFrom)
    {
        TypeEmployee = typeEmp;
        WarningDid = warningDid;        
    }


    public void Print()
    {
        Console.WriteLine($"Employee: {Name}\nCompany: {Company}\nYear from {Name} works: {YearFrom}\nWhat post: {TypeEmployee}\n{WarningDid} times {Name} {TypeEmployee} did warn other employees");
    }
}
