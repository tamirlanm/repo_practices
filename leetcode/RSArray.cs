public class RSArray
{
    public int[] RunningSum(int[] nums)
    {
        int n = nums.Length;
        int[] nums2 = new int[n];
        int rsum = 0;

        for (int i = 0; i < n; i++)
        {
            rsum += nums[i];
            nums2[i] += rsum;
        }
        return nums2;
    }
}