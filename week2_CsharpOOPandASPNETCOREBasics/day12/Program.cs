/*Message mes = Hello;
mes();
Operation op = Add;
int n = op(3, 4);
Console.WriteLine(n);
 
void Hello() => Console.WriteLine("Hello");
int Add(int x, int y) => x + y;
 
delegate int Operation(int x, int y);
delegate void Message();

MessageHandler handler = delegate
{
    Console.WriteLine("анонимный метод");
};
handler("hello world!");    // анонимный метод
 
delegate void MessageHandler(string message);

//Lambda
Message hello = () => Console.WriteLine("Hello");
hello();
hello();

delegate void Message();


var sum = (int x,int y) => Console.WriteLine($"{x} + {y} = {x + y}");
sum(1,2);
sum(12,24);

delegate void Operation(int x, int y);

int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; 
// найдем сумму чисел больше 5
int result1 = Sum(integers, x => x > 5);
Console.WriteLine(result1); // 30
// найдем сумму четных чисел
int result2 = Sum(integers, x => x % 2 == 0);
Console.WriteLine(result2);  //20
int Sum(int[] numbers, IsEqual func)
{
    int result = 0;
    foreach (int i in numbers)
    {
        if (func(i))
            result += i;
    }
    return result;
}
delegate bool IsEqual(int x);
*/

//event example using Account.cs class 

Account account = new Account(100);
account.Notify += DisplayMessage;
account.Put(20);
account.Take(50);
account.Take(170);


/*account.Put(20);
Console.WriteLine($"Сумма на счёте: {account.Sum}");
account.Take(70);
Console.WriteLine($"Сумма на счёте: {account.Sum}");
account.Take(100);
Console.WriteLine($"Сумма на счёте: {account.Sum}");
*/


void DisplayMessage(Account sender, AccountEventArgs e)
{
    Console.WriteLine($"Сумма транзакции: {e.Sum}");
    Console.WriteLine(e.Message);
    Console.WriteLine($"Текущая сумма на счёте: {sender.Sum}");
}

//void DisplayMessage(string message) => Console.WriteLine(message);