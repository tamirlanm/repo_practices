string[] people = {"Tom", "Bob", "Sam", "Tomas"};

var selectedPeople = from p in people where p.ToUpper().StartsWith('T') orderby p select p;

foreach(var per in selectedPeople)
{
    Console.WriteLine(per);
}

int num = (from p in people where p.ToUpper().StartsWith('T') select p).Count();
Console.WriteLine(num);


var people2 = new List<Person>
{
    new Person("Joh",23),
    new Person("Han",24),
    new Person("Jonah",19),
    new Person("Alis",21)
};

var personal = from p in people2 orderby p.Age select new { firstName = p.Name, Year = DateTime.Now.Year - p.Age};

foreach(var per in personal)
{
    Console.WriteLine($"Person: {per.firstName}, Age: {per.Year}");
}