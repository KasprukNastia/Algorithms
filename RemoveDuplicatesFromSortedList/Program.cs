namespace RemoveDuplicatesFromSortedList;

internal class Program
{
    static void Main(string[] args)
    {
        var result = DeleteDuplicates(
            new ListNode(1, new ListNode(1, new ListNode(2))));

        while (result != null)
        {
            Console.Write($"{result.val} ");
            result = result.next;
        }
    }

    public static ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null)
            return head;

        int current = head.val;
        ListNode last = head;
        ListNode temp = head.next;

        while (temp != null)
        {
            if (temp.val != current)
            {
                current = temp.val;
                last.next = temp;
                last = last.next;
            }
            temp = temp.next;
        }

        last.next = null;

        return head;
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