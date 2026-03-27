

string[] people = {"Tom", "Bob", "Sam", "Tomas"};

var selectedPeople = from p in people where p.ToUpper().StartsWith('T') orderby p select p;

foreach(var per in selectedPeople)
{
    Console.WriteLine(per);
}

int num = (from p in people where p.ToUpper().StartsWith('T') select p).Count();
Console.WriteLine($"{num} \n\n---Another example---\n");

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
Console.WriteLine("\n---Another example---\n");

var people3 = new List<Person> {
    new Person("Johan",29),
    new Person("Yasyl",30),
    new Person("Imil",25),
    new Person("Hannibal",28)
};

var personal1 = from p in people3
                let name = $"Mr. {p.Name}"
                let year = DateTime.Now.Year - p.Age
                select new
                {
                    Name = name,
                    Year = year
                };

foreach(var p in personal1)
{
    Console.WriteLine($"{p.Name} - {p.Year}");
}

Console.WriteLine("\n---Another example---\n");

var courses = new List<Course>
{
    new Course("Discrete Structure"),
    new Course("Backned highload"),
    new Course("C#")
};
var students = new List<Student>
{
    new Student("Alissa"),
    new Student("Alex"),
    new Student("Tamik")
};

var enrollments = from course in courses from student in students select new {Student = student.Name, Course = course.Title};

foreach(var enrollment in enrollments)
{
    Console.WriteLine($"{enrollment.Student} - {enrollment.Course}");
}

Console.WriteLine("\n---Another example---\n");

var companies  = new List<Company>
{
    new Company("Microsoft", new List<Person> {new Person("AdamLite",32), new Person("Chad", 31), new Person("Hassan", 28)}),
    new Company("Amazon", new List<Person> {new Person("Sub5",29), new Person("Samsa", 25), new Person("Kando", 51)}),
};
var employees = companies.SelectMany(c => c.Staff);

foreach(var emp in employees)
{
    Console.WriteLine($"Employee name: {emp.Name}");
}
Console.WriteLine();

var employees2 = from c in companies from emp in c.Staff select new{ Name = emp.Name, Company = c.Name};

foreach(var emp in employees2)
{
    Console.WriteLine($"Employee: {emp.Name} - Company: {emp.Company}");
}
