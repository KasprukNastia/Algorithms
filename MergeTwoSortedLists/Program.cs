namespace MergeTwoSortedLists;

internal class Program
{
    static void Main(string[] args)
    {
        var list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
        var list2 = new ListNode(1, new ListNode(3, new ListNode(4)));

        var result = MergeTwoLists(list1, list2);
        while (result != null)
        {
            Console.WriteLine(result.val);
            result = result.next;
        }
    }

    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null)
            return list2;
        if (list2 == null)
            return list1;

        ListNode bigger = list1, smaller = list2;
        if (list1.val < list2.val)
        {
            smaller = list1;
            bigger = list2;
        }

        return new ListNode(smaller.val, MergeTwoLists(smaller.next, bigger));
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}