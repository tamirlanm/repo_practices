// Optimizing the asynchronous programming example 
var tomTask = PrintNameAsync("Tom");
var marcusTask = PrintNameAsync("Marcus");
var anissaTask = PrintNameAsync("Anissa");

//await tomTask;
//await marcusTask;
//await anissaTask;
//await Task.WhenAll(tomTask, marcusTask, anissaTask);
/*
async Task PrintNameAsync(string name)
{
    await Task.Delay(3000);
    Console.WriteLine(name);
}*/

await Task.WhenAny(tomTask, marcusTask, anissaTask);
async Task PrintNameAsync(string message)
{
    await Task.Delay(new Random().Next(1000,2000));
    Console.WriteLine(message);
}

// Another example using Task Asynchronous method

var task = PrintAsync("Welcome to the C# World!");
Console.WriteLine("Main Works");

await task;

async Task PrintAsync(string message){
    await Task.Delay(0);
    Console.WriteLine(message);
}

// Example using Task<T>  Asynchronous method

int n1 = await SquareAsync(5);
int n2 = await SquareAsync(7);
Console.WriteLine($"n1 = {n1}, n2 = {n2}");

async Task<int> SquareAsync(int n){
    await Task.Delay(1000);
    return n*n;
}

// Another example of using Task.WhenAll. Getting results

var task1 = SquareAsync(6);
var task2 = SquareAsync(8);
var task3 = SquareAsync(10);

await Task.WhenAll(task1,task2,task3);
Console.WriteLine($"task2 result: {task2.Result}");
//int[] results = await Task.WhenAll(task1,task2,task3);

//foreach(int result in results)
//{
//    Console.WriteLine(result);
//}


// Example error handling in Asynchronous programming

var newTask1 = NewPrintAsync("H");
var newTask2 = NewPrintAsync("H2");
var newTask3 = NewPrintAsync("Using Key Word!!");
var allnewTasks = Task.WhenAll(newTask1, newTask2, newTask3);

try
{
    await allnewTasks;
}
catch(Exception ex)
{
    Console.WriteLine($"Exception: {ex.Message}");
    Console.WriteLine($"IsFaulted: {allnewTasks.IsFaulted}");
    if(allnewTasks.Exception is not null)
    {
        foreach(var exception in allnewTasks.Exception.InnerExceptions)
        {
            Console.WriteLine($"InnerException: {exception.Message}");
        }
    }
}

async Task NewPrintAsync(string message)
{
    if(message.Length < 3)
    {
        throw new ArgumentException($"Invalid string: {message}");
    }
    await Task.Delay(1200);
    Console.WriteLine(message);
}