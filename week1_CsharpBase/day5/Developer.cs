
using System.Dynamic;

class Developer : Employee
{
    
    public DeveloperPost Post;

    public Developer(string name, string company, string typeEmp, int yearFrom,  DeveloperPost post) 
    : base(name,company,yearFrom){
        TypeEmployee = typeEmp;
        Post = post;
    }
    public void Print() => Console.WriteLine($"Employee's name: {Name}\nWhat Company's at his working: {Company}\nType of Employee: {TypeEmployee}\nHe is working at {Company} from: {YearFrom}\nWhat Level developer he is: {Post}");
}