/*Message mes = Hello;
mes();
Operation op = Add;
int n = op(3, 4);
Console.WriteLine(n);
 
void Hello() => Console.WriteLine("Hello");
int Add(int x, int y) => x + y;
 
delegate int Operation(int x, int y);
delegate void Message();
*/
MessageHandler handler = delegate
{
    Console.WriteLine("анонимный метод");
};
handler("hello world!");    // анонимный метод
 
delegate void MessageHandler(string message);