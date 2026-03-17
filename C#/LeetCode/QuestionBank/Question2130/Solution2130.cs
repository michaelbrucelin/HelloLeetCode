using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2130
{
    public class Solution2130 : Interface2130
    {
        /// <summary>
        /// 两轮遍历
        /// 使用栈缓存
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int PairSum(ListNode head)
        {
            List<int> list = [];
            ListNode ptr = head;
            while (ptr != null) { list.Add(ptr.val); ptr = ptr.next; }

            int result = 0;
            ptr = head;
            for (int i = list.Count - 1, j = list.Count >> 1; i >= j; i--)
            {
                result = Math.Max(result, ptr.val + list[i]);
                ptr = ptr.next;
            }

            return result;
        }

        /// <summary>
        /// 逻辑同PairSum()，改为使用栈缓存
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int PairSum2(ListNode head)
        {
            Stack<int> stack = [];
            ListNode ptr = head;
            while (ptr != null) { stack.Push(ptr.val); ptr = ptr.next; }

            int result = 0;
            ptr = head;
            for (int i = stack.Count - 1, j = stack.Count >> 1; i >= j; i--)
            {
                result = Math.Max(result, ptr.val + stack.Pop());
                ptr = ptr.next;
            }

            return result;
        }
    }
}
