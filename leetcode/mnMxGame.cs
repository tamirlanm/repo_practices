public class mnMxGame
{
    public int MinMaxGame(int[] nums)
    {
        int n = nums.Length;

        while (n > 1)
        {
            n /= 2;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    nums[i] = Math.Min(nums[2 * i], nums[2 * i + 1]);
                }
                else
                {
                    nums[i] = Math.Max(nums[2 * i], nums[2 * i + 1]);
                }
            }
        }
        return nums[0];
    }
}