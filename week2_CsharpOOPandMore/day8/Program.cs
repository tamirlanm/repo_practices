try
{
    TestClass.Method1();
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Catch in Main: {ex.Message}");
}
finally
{
    Console.WriteLine("Block finally in Main");
}
Console.WriteLine("End method of Main");