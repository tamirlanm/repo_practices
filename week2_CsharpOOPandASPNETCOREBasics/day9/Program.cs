/*Person<int> person = new Person<int>(546, "Tom");
Company<Person<int>> microsoft = new Company<Person<int>>(person);
Console.WriteLine("--- Company with <T> Person ---");
Console.WriteLine(microsoft.CEO.Id);
Console.WriteLine(microsoft.CEO.Name);
Console.WriteLine();

int x =7;
int y =25;
Swap(ref x, ref y);
Console.WriteLine($"x = {x}, y = {y}");

string x2 = "meta";
string y2 = "aoi";
Swap(ref x2, ref y2);
Console.WriteLine($"x = {x2}, y = {y2}");

void Swap<T>(ref T x, ref T y)
{
    T temp = x;
    x = y;
    y = temp;
}
*/

Messanger<Message, Person> whatsapp = new Messanger<Message, Person>();
Person tom = new Person("Tom");
Person sam = new Person("Sam");
Message congrats = new Message("Hello! We received your answers. And we congratulate you! You are the one of the first person who achieved that high score!");
whatsapp.SendMessage(tom, sam, congrats);

Console.WriteLine();

Box<string> box = new Box<string>("String Object!!!");
box.Show();
Console.WriteLine();

Repository<string> names = new Repository<string>();
names.Add("Alex");
names.Add("Britney");
names.Add("James");
foreach(var name in names.GetAll())
{
    Console.Write($"{name}, ");
}
Console.WriteLine();
names.Remove("Britney");
names.Show();

Console.WriteLine();

Response<string> resp1 = new Response<string>(false,"Failed", "Hello");
Response<int> resp2 = new Response<int>(true, "Success", 153);
Console.WriteLine(resp1.Data);
Console.WriteLine(resp2.Data);