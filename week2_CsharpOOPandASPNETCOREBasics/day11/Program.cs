using System;
using System.Threading.Tasks;

class Program
{
    static async Task<string> GetUserName()
    {
        await Task.Delay(1500);
        return "Johnson";
    }

    
    static async Task<string> ReadingData()
    {
        await Task.Delay(2000);
        return "Data is uploaded";
    }

    static async Task Main()
    {
        Console.WriteLine("Getting you'r name...");

        string[] result = await Task.WhenAll(GetUserName(),ReadingData());
        Console.WriteLine(result[0]);
        Console.WriteLine(result[1]);


        /*       
        string name = await GetUserName();
        string res = await ReadingData();
        Console.WriteLine(res);
        Console.WriteLine($"Finally {name}");
        */
    }


}