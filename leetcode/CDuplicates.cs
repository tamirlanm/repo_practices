public class CDuplicates
{
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> newNums = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!newNums.Contains(nums[i]))
            {
                newNums.Add(nums[i]);
            }
            else
            {
                return true;
            }
        }
        return false;
    }
}