class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        int sum = 0;
        int max = int.MinValue;
        string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(input[i]);
            sum += arr[i];
            if(max < arr[i])
            {
                max = arr[i];
            }
        }
        string s = Console.ReadLine();
        string t = "";
        int c = 0;
        //StringBuilder rev = new StringBuilder(s.Length);
        for(int i = s.Length - 1; i >=0; i--)
        {
            //rev.Append(s[i]);   
            t+= s[i];
            if (s[i] == 'i' || s[i] == 'o' || s[i] == 'y' || s[i] == 'u' || s[i] == 'e' || s[i] == 'a')
            {
                c++;
            }
        }

        Console.WriteLine($"Sum: {sum} \nMaximum in arr: {max}\nReverse string: {t}\nCountGlasnyih: {c}");

    }
}