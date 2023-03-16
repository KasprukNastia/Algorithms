namespace TwoSum;

internal class Program
{
    static void Main(string[] args)
    {
        foreach (var index in TwoSum(new []{ 3, 2, 4 }, 6))
        {
            Console.WriteLine(index);
        }
    }

    public static int[] TwoSum(int[] nums, int target)
    {
        int[] result = new int[] { -1, -1 };

        var numsSorted =
            nums.Select((n, index) => new Element(n, index)).ToArray();
        var comparer = new ElementComparer();
        Array.Sort(numsSorted, comparer);

        for (int i = 0; i < nums.Length; i++)
        {
            var elementToFind = new Element(target - nums[i]);
            var elementIndex = Array.BinarySearch(
                numsSorted, elementToFind, comparer);
            if (elementIndex >= 0 && i != numsSorted[elementIndex].Index)
            {
                result[0] = i;
                result[1] = numsSorted[elementIndex].Index;

                return result;
            }
        }

        return result;
    }

    class Element
    {
        public int Value { get; }
        public int Index { get; }

        public Element(int value, int index = -1)
        {
            Value = value;
            Index = index;
        }
    }

    class ElementComparer : IComparer<Element>
    {
        public int Compare(Element? x, Element? y)
        {
            if (x.Value == y.Value)
                return 0;
            return x.Value > y.Value ? 1 : -1;
        }
    }
}