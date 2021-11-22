using System;
using System.Collections.Generic;

namespace RemoveLinkedListElementsApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var array = new int[] { 1, 2, 6, 3, 4, 5, 6 };
            var nodeList = new List<ListNode>
            {
                new ListNode(1, new ListNode(2, new ListNode(6, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, new ListNode())))))))
            };

            foreach (var node in nodeList)
                RemoveElements(node, 6);

            foreach (var node in nodeList)
                Console.WriteLine(node.Val);


            Console.ReadKey();
        }

        public static ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
                return null;

            var rightSideHead = RemoveElements(head.Next, val);
            if (head.Val == val)
                return rightSideHead;

            head.Next = rightSideHead;
            return head;
        }


        //Definition for singly-linked list.
        public class ListNode
        {
            public int Val;
            public ListNode Next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.Val = val;
                this.Next = next;
            }
        }

    }
}
