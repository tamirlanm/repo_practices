class Program
{
    public static void Main(string[] args)
    {
        Person person = new Person("Alexa", 42);
        person.Print();
        person.Age = 120;
        person.Print();
        person.Age = 19;
        person.Print();
        BankAccount bankAcc = new BankAccount("John", 100000);
        Console.WriteLine($"Bank Account Owner: {bankAcc._owner}\nBank Account: {bankAcc.Balance}");
        bankAcc.Balance = -2500;
        Console.WriteLine($"Bank Balance: {bankAcc.Balance}");
    }
}