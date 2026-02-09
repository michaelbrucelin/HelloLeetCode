using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0154
{
    public class Solution0154 : Interface0154
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node CopyRandomList(Node head)
        {
            if (head == null) return null;

            Dictionary<Node, Node> map = new Dictionary<Node, Node>();
            Node HEAD = new Node(head.val);
            map.Add(head, HEAD);
            Node p1 = head, p2 = HEAD;
            while (p1 != null)
            {
                if (p1.next != null)
                {
                    if (map.TryGetValue(p1.next, out Node value))
                    {
                        p2.next = value;
                    }
                    else
                    {
                        Node next = new Node(p1.next.val); p2.next = next; map.Add(p1.next, next);
                    }
                }
                if (p1.random != null)
                {
                    if (map.TryGetValue(p1.random, out Node value))
                    {
                        p2.random = value;
                    }
                    else
                    {
                        Node random = new Node(p1.random.val); p2.random = random; map.Add(p1.random, random);
                    }
                }
                p1 = p1.next; p2 = p2.next;
            }

            return HEAD;
        }
    }
}
