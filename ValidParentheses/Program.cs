namespace ValidParentheses;

internal class Program
{
    private static Dictionary<char, char> _pairs = new()
    {
        { '{', '}' },
        { '(', ')' },
        { '[', ']' }
    };

    static void Main(string[] args)
    {
        Console.WriteLine(IsValid("(("));
    }

    public static bool IsValid(string s)
    {
        if (s.Length % 2 != 0)
            return false;

        var stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (_pairs.TryGetValue(s[i], out var pair))
            {
                stack.Push(s[i]);
            }
            else
            {
                if (stack.Count == 0 || _pairs[stack.Pop()] != s[i])
                    return false;
            }
        }

        return stack.Count == 0;
    }
}