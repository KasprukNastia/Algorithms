namespace RomantoInteger;

internal class Program
{
    private static Dictionary<char, int> _romanToIntSimpleValues = new()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };

    private static Dictionary<string, int> _romanToIntComplexValues = new()
    {
        { "IV", 4 },
        { "IX", 9 },
        { "XL", 40 },
        { "XC", 90 },
        { "CD", 400 },
        { "CM", 900 }
    };

    static void Main(string[] args)
    {
        Console.WriteLine(RomanToIntAlternative("LVIII"));
    }

    public static int RomanToInt(string s)
    {
        int result = 0;

        var str = new LinkedList<char>(s);

        while (str.Count > 0)
        {
            var char1 = str.First.Value;
            str.RemoveFirst();
            var char2 = str.First?.Value;
            if (char2.HasValue && _romanToIntComplexValues.TryGetValue($"{char1}{char2}", out var found))
            {
                str.RemoveFirst();
                result += found;
            }
            else
            {
                result += _romanToIntSimpleValues[char1];
            }
        }

        return result;
    }

    public static int RomanToIntAlternative(string s)
    {
        int result = 0;

        for (int i = 0; i < s.Length - 1; i++)
        {
            if (_romanToIntSimpleValues[s[i]] < _romanToIntSimpleValues[s[i + 1]])
                result -= _romanToIntSimpleValues[s[i]];
            else
                result += _romanToIntSimpleValues[s[i]];
        }
        result += _romanToIntSimpleValues[s[s.Length - 1]];

        return result;
    }
}