public class Solution
{
    public int MaximumWealth(int[][] accounts)
    {
        int m = accounts.Length;

        int max = 0;

        for (int i = 0; i < m; i++)
        {
            int sum = 0;
            int n = accounts[i].Length;
            for (int j = 0; j < n; j++)
            {
                sum += accounts[i][j];
            }
            if (sum > max)
            {
                max = sum;
            }
        }
        return max;
    }
}
}
