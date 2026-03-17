using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2130
{
    public class Solution2130_2 : Interface2130
    {
        /// <summary>
        /// 快慢指针
        /// 借助快慢指针，只缓存一半的数据
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int PairSum(ListNode head)
        {
            ListNode dummy = new ListNode() { next = head };
            ListNode p1 = dummy, p2 = dummy;
            while (p2.next != null) { p1 = p1.next; p2 = p2.next.next; }

            List<int> list = [];
            while ((p1 = p1.next) != null) list.Add(p1.val);

            int result = 0; p1 = head;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                result = Math.Max(result, p1.val + list[i]);
                p1 = p1.next;
            }
            return result;
        }
    }
}
