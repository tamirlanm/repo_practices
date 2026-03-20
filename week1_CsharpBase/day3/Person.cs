
using System.Reflection.Metadata.Ecma335;

class Person
{
    private string _name;
    private int _age;

    public Person(string name, int age)
    {
        _name = name;
        Age = age;
    }
    
    public string Name { 
        get {return _name;}
        set {_name = value;}
    }
    public int Age
    {
        get{ return _age;}
        set
        {
            if(value > 0 && value < 120)
            {
                _age = value ;
            }
        }
    }
    public void Print() => Console.WriteLine($"Person name: {_name}\nPerson age: {_age}");
}