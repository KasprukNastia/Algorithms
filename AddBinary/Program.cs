namespace AddBinary;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(AddBinary("1010", "1011"));
    }

    public static string AddBinary(string a, string b)
    {
        string shorter = a, longer = b;
        if (a.Length > b.Length)
        {
            shorter = b;
            longer = a;
        }

        var stack = new Stack<char>();
        int difference = longer.Length - shorter.Length;
        bool transfer = false;
        for (int i = shorter.Length - 1; i >= 0; i--)
        {
            if (shorter[i] == '1' && longer[i + difference] == '1')
            {
                stack.Push(transfer ? '1' : '0');
                transfer = true;
            }
            else if(shorter[i] == '0' && longer[i + difference] == '0')
            {
                stack.Push(transfer ? '1' : '0');
                transfer = false;
            }
            else
            {
                stack.Push(transfer ? '0' : '1');
            }
        }

        for (int i = difference - 1; i >= 0; i--)
        {
            if (longer[i] == '1')
            {
                stack.Push(transfer ? '0' : '1');
            }
            else
            {
                if (transfer)
                {
                    stack.Push('1');
                    transfer = false;
                }
                else
                {
                    stack.Push('0');
                }
            }
        }

        if(transfer)
            stack.Push('1');

        return new string(stack.ToArray());
    }
}