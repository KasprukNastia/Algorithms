namespace MergeSortedArray;

internal class Program
{
    static void Main(string[] args)
    {
        var result = new[] { 1, 2, 3, 0, 0, 0 };
        Merge(result, 3, new[] { 2, 5, 6 }, 3);

        foreach (var elem in result)
        {
            Console.Write($"{elem} ");
        }
    }

    public static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int current = m + n - 1;
        m--;
        n--;
        while (m >= 0 && n >= 0)
        {
            if (nums1[m] >= nums2[n])
            {
                nums1[current] = nums1[m];
                m--;
            }
            else
            {
                nums1[current] = nums2[n];
                n--;
            }
            current--;
        }

        while (m >= 0)
        {
            nums1[current] = nums1[m];
            m--;
            current--;
        }

        while (n >= 0)
        {
            nums1[current] = nums2[n];
            n--;
            current--;
        }
    }
}