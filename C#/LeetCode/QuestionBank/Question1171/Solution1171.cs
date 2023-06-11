using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1171
{
    public class Solution1171 : Interface1171
    {
        /// <summary>
        /// 前缀和
        /// 具体分析见Solution1171.md
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode RemoveZeroSumSublists(ListNode head)
        {
            ListNode dummy = new ListNode(0, head);
            Dictionary<int, ListNode> map = new Dictionary<int, ListNode>();
            int pre; ListNode ptr; bool flag = true;
            while (flag)
            {
                flag = false; map.Clear(); pre = 0; ptr = dummy;
                while (ptr != null)
                {
                    pre += ptr.val;
                    if (map.ContainsKey(pre))
                    {
                        map[pre].next = ptr.next; flag = true; break;
                    }
                    else
                    {
                        map.Add(pre, ptr);
                    }
                    ptr = ptr.next;
                }
            }

            return dummy.next;
        }
    }
}
