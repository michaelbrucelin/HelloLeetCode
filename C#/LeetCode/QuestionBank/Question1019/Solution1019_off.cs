using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1019
{
    public class Solution1019_off : Interface1019
    {
        public int[] NextLargerNodes(ListNode head)
        {
            List<int> result = new List<int>();
            Stack<(int val, int id)> stack = new Stack<(int val, int id)>();
            ListNode ptr = head; int id = 0;
            while (ptr != null)
            {
                result.Add(0);
                while (stack.Count > 0 && ptr.val > stack.Peek().val)
                    result[stack.Pop().id] = ptr.val;
                stack.Push((ptr.val, id++));
                ptr = ptr.next;
            }

            return result.ToArray();
        }
    }
}
