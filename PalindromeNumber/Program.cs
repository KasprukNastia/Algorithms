namespace PalindromeNumber;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(IsPalindrome(10));
    }

    public static bool IsPalindrome(int x)
    {
        if (x < 0)
            return false;

        var queue = new Queue<int>();

        int pow = -1;
        int copy = x;
        while (copy > 0)
        {
            var toEnqueue = copy % 10;
            queue.Enqueue(toEnqueue);
            copy = (copy - toEnqueue) / 10;
            pow++;
        }

        copy = 0;
        while (queue.Count > 0)
        {
            copy += (int)(queue.Dequeue() * Math.Pow(10, pow));
            pow--;
        }

        return x == copy;
    }
}