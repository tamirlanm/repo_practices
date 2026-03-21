using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Shape rectangle = new Rectangle(13.4,12);
        Shape circle = new Circle(5.6);

        double rectArea = rectangle.Area();
        double rectPer = rectangle.Perimeter();
        Console.WriteLine($"Rectangle Area: {rectArea}\nRectangle Perimeter: {rectPer}\n");

        double circArea = circle.Area();
        double circPer = circle.Perimeter();
        Console.WriteLine($"Circle Area: {circArea}\nCircle Perimeter: {circPer}"); 
    }
}