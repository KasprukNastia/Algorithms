namespace RemoveElement;

internal class Program
{
    static void Main(string[] args)
    {
        var input = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };

        var result = RemoveElement(input, 2);

        Console.WriteLine($"Result: {result}");
        Console.WriteLine();

        for (int i = 0; i < result; i++)
        {
            Console.Write($"{input[i]} ");
        }
    }

    public static int RemoveElement(int[] nums, int val)
    {
        int notEqualToVal = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[notEqualToVal] = nums[i];
                notEqualToVal++;
            }
        }

        return notEqualToVal;
    }
}