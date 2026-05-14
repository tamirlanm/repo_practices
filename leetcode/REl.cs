
public class REl
{
    public int RemoveElement(int[] nums, int val)
    {
        int n = nums.Length;
        int[] newNums = new int[n];

        void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        int interPos = 0;

        for(int i = 0; i < n; i++)
        {
            if(nums[i] != val)
            {
                Swap(nums, i, interPos);
                interPos++;
            }
        }
        for(int i = 0; i < n; i++)
        {
            if(nums[i] != val)
            {
                newNums[i] = nums[i];
            }
        }
        return interPos;
        //return (interPos, newNums);
    }
}