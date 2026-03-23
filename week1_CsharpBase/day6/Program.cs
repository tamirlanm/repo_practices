using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Shape rectangle = new Rectangle(13.4,12);
        Shape circle = new Circle(5.6);
        Person person = new Person();
        BaseAction action1 = new BaseAction();
        HeroAction action2 = new HeroAction();

        double rectArea = rectangle.Area();
        double rectPer = rectangle.Perimeter();
        Console.WriteLine($"Rectangle Area: {rectArea}\nRectangle Perimeter: {rectPer}\n");

        double circArea = circle.Area();
        double circPer = circle.Perimeter();
        Console.WriteLine($"Circle Area: {circArea}\nCircle Perimeter: {circPer}"); 

        Console.WriteLine($"\n");
        person.Move();
        Console.WriteLine();
        action1.Move();
        action2.Move();
    }
}