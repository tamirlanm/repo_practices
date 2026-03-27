string[] people = {"Tom", "Bob", "Sam", "Tomas"};

var selectedPeople = from p in people where p.ToUpper().StartsWith('T') orderby p select p;

foreach(var per in selectedPeople)
{
    Console.WriteLine(per);
}

int num = (from p in people where p.ToUpper().StartsWith('T') select p).Count();
Console.WriteLine(num);