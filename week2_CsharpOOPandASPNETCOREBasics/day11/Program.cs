var tomTask = PrintNameAsync("Tom");
var marcusTask = PrintNameAsync("Marcus");
var anissaTask = PrintNameAsync("Anissa");

await tomTask;
await marcusTask;
await anissaTask;

async Task PrintNameAsync(string name)
{
    await Task.Delay(3000);
    Console.WriteLine(name);
}