class Person
{
    public string Name { get; set; }
    public int Age {  get; set; }

    public Person(string name, int age)
    {
        Name = name; 
        Age = age;
    }
    public void PrintInfo() => Console.WriteLine($"Person's name:{Name}\nPerson's age:{Age}");

}