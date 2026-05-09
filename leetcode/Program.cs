class Program
{
    public static void Main(string[] args)
    {
        CDuplicates cd = new CDuplicates();
        int n = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int[] nums = new int[n];
        for(int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(input[i]);
        }
        bool tr = cd.ContainsDuplicate(nums);
        Console.WriteLine(tr);
        /*
        SearchInsertPosition ss = new SearchInsertPosition();
        int n = int.Parse(Console.ReadLine());
        int target = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int[] nums = new int[n];
        for(int i = 0;i < n; i++)
        {
            nums[i] = int.Parse(input[i]);
        }
        
        int t = ss.SearchInsert(nums, target);
        Console.WriteLine($"Result: {t}");
        */
    }
}