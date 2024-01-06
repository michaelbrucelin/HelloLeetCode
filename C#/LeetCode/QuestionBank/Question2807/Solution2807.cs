using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2807
{
    public class Solution2807 : Interface2807
    {
        public ListNode InsertGreatestCommonDivisors(ListNode head)
        {
            if (head == null) return null;

            ListNode ptr = head; int gcd;
            while (ptr.next != null)
            {
                gcd = GetGCD(ptr.val, ptr.next.val);
                ListNode node = new ListNode(gcd);
                node.next = ptr.next;
                ptr.next = node;
                ptr = node.next;
            }

            return head;
        }

        private int GetGCD(int x, int y)
        {
            if (x == y) return x;

            int move = 0;
            while (x != y) switch ((x & 1, y & 1))
                {
                    case (0, 0): x >>= 1; y >>= 1; move++; break;
                    case (0, 1): x >>= 1; break;
                    case (1, 0): y >>= 1; break;
                    default:  // (1, 1)
                        if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                        break;
                }

            return x << move;
        }
    }
}
