namespace PlusOne;

internal class Program
{
    static void Main(string[] args)
    {
        foreach (var elem in PlusOne(new []{9}))
        {
            Console.Write($"{elem} ");
        }
    }

    public static int[] PlusOne(int[] digits)
    {
        int i = digits.Length - 1;
        while (i >= 0 && digits[i] == 9)
        {
            digits[i] = 0;
            i--;
        }

        if (i < 0)
        {
            var result = new int[digits.Length + 1];
            result[0] = 1;
            Array.Copy(digits, 0, result, 1, digits.Length);
            return result;
        }

        digits[i] += 1;

        return digits;
    }
}