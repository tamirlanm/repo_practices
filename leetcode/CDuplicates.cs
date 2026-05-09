using System.Collections;

public class CDuplicates
{
    public bool ContainsDuplicate(int[] nums)
    {
        Dictionary<int, int> map = new Dictionary<int,int>();
        for(int i = 0; i < nums.Length; i++)
        {
            if (map.ContainsKey(nums[i]))
            {
                return true;
            }
            map[nums[i]] = i;
        }
        return false;
        /*
        HashSet<int> set = new HashSet<int>();
        foreach(int num in nums){
            if(set.Contains(num)){
                return true;
            }
            set.Add(num);
        }
        return false;
        */

        /*    
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
        return false;*/


    }
}