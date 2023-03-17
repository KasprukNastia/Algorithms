namespace SearchInsertPosition;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(SearchInsert(new []{ 1, 3 }, 0));
    }

    public static int SearchInsert(int[] nums, int target)
    {
        int first = 0,
            last = nums.Length,
            mid = last / 2;

        if (nums.Length < 3)
        {
            mid = 1;
        }

        while (mid > 0 && mid < nums.Length - 1)
        {
            if (nums[mid] == target)
                return mid;
            if (nums[mid] < target && nums[mid + 1] >= target)
                return mid + 1;

            if (nums[mid + 1] < target)
            {
                first = mid + 1;
            }
            else if (nums[mid] > target)
            {
                last = mid;
            }
            mid = first + (last - first) / 2;
        }

        if (mid == 0 && nums[mid] >= target)
            return 0;

        if (mid == nums.Length - 1 && nums[mid] < target)
            return nums.Length;

        return mid + 1;
    }
}