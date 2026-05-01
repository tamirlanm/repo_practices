
public class SearchInsertPosition
{
    public int SearchInsert(int[] nums, int target)
    {
        int mid = nums.Length/2;
        int j = 0;
        for(int i = 0; i < mid; i++)
        {
            if(target <= nums[i])
            {
                return j;
            }
            else if(nums[i] == target)
            {
                return i;
            }    
            j++;
        }
        for(int i = mid; i < nums.Length; i++)
        {
            if(target <= nums[i])
            {
                return j;
            }
            else if(nums[i] == target)
            {
                return i;
            }
            j++;
        }
        return j++;
    }
}