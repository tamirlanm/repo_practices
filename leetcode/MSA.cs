public class MSA
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        for (int i = 0; i < m + n; i++)
        {
            if (i >= m)
            {
                nums1[i] = nums2[i - m];
            }
        }
        Array.Sort(nums1);
    }
}