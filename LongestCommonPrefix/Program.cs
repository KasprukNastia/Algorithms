namespace LongestCommonPrefix;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(LongestCommonPrefix(new []{ "dog", "racecar", "car" }));
    }

    public static string LongestCommonPrefix(string[] strs)
    {
        Array.Sort(strs);

        var smaller = strs[0];
        var bigger = strs[strs.Length - 1];
        if (smaller.Length > bigger.Length)
        {
            smaller = bigger;
            bigger = strs[0];
        }

        while (!bigger.StartsWith(smaller))
        {
            smaller = smaller.Substring(0, smaller.Length - 1);
        }

        return smaller;
    }
}