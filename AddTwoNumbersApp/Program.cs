using System;

namespace AddTwoNumbersApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode headL1 = l1;
            ListNode headL2 = l2;
            ListNode current = dummyHead;
            int carry = 0;

            while (headL1 != null || current != null)
            {
                int x = (headL1 != null) ? headL1.val : 0;
                int y = (current != null) ? current.val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                current.next = new ListNode(sum % 10);
                current = current.next;
                if (headL1 != null) headL1 = headL1.next;
                if (headL1 != null) headL2 = headL2.next;
            }
            if (carry > 0)
            {
                current.next = new ListNode(carry);
            }

            return dummyHead.next;
        }
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
