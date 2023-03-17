namespace RemoveDuplicatesFromSortedArray;

internal class Program
{
    static void Main(string[] args)
    {
        var input = new int[] { 1, 2 };

        var result = RemoveDuplicates(input);

        Console.WriteLine($"Result: {result}");
        Console.WriteLine();

        for (int i = 0; i < result; i++)
        {
            Console.Write($"{input[i]} ");
        }
    }

    public static int RemoveDuplicates(int[] nums)
    {
        int last = 0,
            next = 1,
            pivot = 0,
            duplicates = 0;

        while (next != nums.Length)
        {
            if (nums[last] == nums[next])
            {
                duplicates++;
                pivot = last + 1;
            }
            else
            {
                if(duplicates > 0)
                    nums[pivot] = nums[next];
                pivot++;
                last++;
            }

            next++;
        }

        return nums.Length - duplicates;
    }
}