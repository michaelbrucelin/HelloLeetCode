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
        /// 1. 添加哑节点
        /// 2. 遍历链表，整理前缀和字典，key是和，值是第一个以及最后一个前缀和是key的id
        ///     例如：id:  0  1  2  3  4  5
        ///           val: 0  1  2  3 -3 -2
        ///           sum: 0  1  3  6  3  1
        ///           key  value
        ///           0    [0, 0]
        ///           1    [1, 5]
        ///           3    [2, 4]
        ///           6    [3, 3]
        /// 3. 当有两个不同的id的和相等时，(id1, id2]之间的结点就可以删除了
        ///     当然如果多组不重合的，是可以一并删除的
        ///     如果两组之间有重合，这里取范围更大的一组，范围一样大，就取更靠前的一组
        /// 4. 重复2 3两个步骤，直至不存在连续和为0的区间段
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode RemoveZeroSumSublists(ListNode head)
        {
            ListNode dummy = new ListNode(0, head);
            List<int> pre = new List<int>() { 0 };
            int id = 0; ListNode ptr = dummy;
            while ((ptr = ptr.next) != null)
            {
                pre.Add(pre[id++] + ptr.val);
            }

            return dummy.next;
        }
    }
}
