using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0203
{
    public class Solution0203 : Interface0203
    {
        /// <summary>
        /// 读懂题
        /// 没读懂题，删除的不是节点，而是某一个节点的值？先按照这个理解去写
        /// 竟然就是这个意思... ...，题目描述严重缺乏严谨性
        /// </summary>
        /// <param name="node"></param>
        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;  // 题目限定node是中间节点
            node.next = node.next.next;
        }
    }
}
