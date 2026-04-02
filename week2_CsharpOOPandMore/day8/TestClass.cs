class TestClass
{
    public static void Method1()
    {
        try
        {
            Method2();
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Catch in Method1: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Block finally in Method1");
        }
        Console.WriteLine("End method of Method1");
    }
    static void Method2()
    {
        try
        {
            int x = 8;
            int y = x / 0;
        }
        finally
        {
            Console.WriteLine("Block finally in Method2");
        }
        Console.WriteLine("End method of Method2");
    }
}