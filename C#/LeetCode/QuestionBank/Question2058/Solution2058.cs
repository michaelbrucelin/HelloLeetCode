using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2058
{
    public class Solution2058 : Interface2058
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int[] NodesBetweenCriticalPoints(ListNode head)
        {
            ListNode ptr = head.next; int idx = 1, prev = head.val;
            List<int> idxs = [];
            while (ptr.next != null)
            {
                if (1L * (ptr.val - prev) * (ptr.val - ptr.next.val) > 0) idxs.Add(idx);
                prev = ptr.val;
                ptr = ptr.next;
                idx++;
            }
            if (idxs.Count < 2) return [-1, -1];

            int[] result = [int.MaxValue, idxs[^1] - idxs[0]];
            for (int i = 1, cnt = idxs.Count; i < cnt; i++) result[0] = Math.Min(result[0], idxs[i] - idxs[i - 1]);
            return result;
        }
    }
}
