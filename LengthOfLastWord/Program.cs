namespace LengthOfLastWord;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(LengthOfLastWord("   fly me   to   the moon  "));
    }

    public static int LengthOfLastWord(string s)
    {
        int counter = 0;

        int i = s.Length - 1;
        while (i >= 0)
        {
            if (s[i] != ' ')
                counter++;
            if (s[i] == ' ' && counter > 0)
                return counter;
            i--;
        }

        return counter;
    }
}