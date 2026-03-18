public class Solution
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        int m = nums2.Length;
        HashSet<int> nums3 = new HashSet<int>();
        HashSet<int> set2 = nums2.ToHashSet();
        for (int i = 0; i < n; i++)
        {
            if (set2.Contains(nums1[i]))
            {
                nums3.Add(nums1[i]);
            }
        }
        return nums3.ToArray();
    }
}