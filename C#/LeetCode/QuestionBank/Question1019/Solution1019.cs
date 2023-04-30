using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1019
{
    public class Solution1019 : Interface1019
    {
        /// <summary>
        /// 单调栈
        /// 1. 将链表转为数组
        /// 2. 从后向前遍历数组，利用单调栈更新数组的值
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int[] NextLargerNodes(ListNode head)
        {
            List<int> result = new List<int>();
            ListNode ptr = head;
            while (ptr != null) { result.Add(ptr.val); ptr = ptr.next; }

            Stack<int> stack = new Stack<int>();
            for (int i = result.Count - 1, val; i >= 0; i--)
            {
                val = result[i];
                while (stack.Count > 0 && stack.Peek() <= val) stack.Pop();
                result[i] = stack.Count > 0 ? stack.Peek() : 0;
                stack.Push(val);
            }

            return result.ToArray();
        }
    }
}
