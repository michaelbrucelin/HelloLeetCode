using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0028
{
    public class Solution0028_2 : Interface0028
    {
        /// <summary>
        /// 栈
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node Flatten(Node head)
        {
            if (head == null) return head;

            Node ptr = head, next, child, tail;
            Stack<Node> stack = new Stack<Node>();
            while (ptr != null)
            {
                child = ptr.child; next = ptr.next;
                switch ((child, next))
                {
                    case (null, null):
                        if (stack.Count == 0) { ptr = null; break; }
                        tail = ptr; ptr = stack.Pop(); tail.next = ptr; ptr.prev = tail;
                        break;
                    case (null, _):
                        ptr = next;
                        break;
                    case (_, null):
                        ptr.next = child; ptr.child = null; child.prev = ptr; ptr = child;
                        break;
                    case (_, _):
                        stack.Push(next); ptr.next = child; ptr.child = null; child.prev = ptr; ptr = child;
                        break;
                }
            }

            return head;
        }
    }
}
