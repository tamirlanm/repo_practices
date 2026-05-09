public class twsum
{
    public int[] TwoSum(int[] nums, int target)
    {
        /*
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (target == nums[i] + nums[j])
                {
                    return new int[] { i, j };
                }
            }
        }
        return Array.Empty<int>();*/
        Dictionary<int,int> map = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++)
        {
            map[nums[i]] = i;
        }
        for(int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if(map.ContainsKey(complement) && map[complement] != i)
            {
                return new int[] {i, map[complement]};
            }
        }
        return new int[] {};
    }
}