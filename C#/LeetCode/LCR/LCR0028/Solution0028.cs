using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0028
{
    public class Solution0028 : Interface0028
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node Flatten(Node head)
        {
            if (head == null) return head;
            rec(head);
            return head;

            static Node rec(Node head)
            {
                Node child = head.child, next = head.next;
                switch (child, next)
                {
                    case (null, null): return head;
                    case (null, _): return rec(next);
                    case (_, null):
                        child.prev = head; head.next = child; head.child = null;
                        return rec(head.next);
                    case (_, _):
                        Node tail = rec(child);
                        head.next = child; head.child = null; child.prev = head;
                        tail.next = next; next.prev = tail;
                        return rec(next);
                }
            }
        }
    }
}
