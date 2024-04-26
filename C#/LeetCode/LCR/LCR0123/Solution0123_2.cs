using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0123
{
    public class Solution0123_2 : Interface0123
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int[] ReverseBookList(ListNode head)
        {
            if (head == null) return [];

            return (new List<int>(ReverseBookList(head.next)) { head.val }).ToArray();
        }
    }
}
