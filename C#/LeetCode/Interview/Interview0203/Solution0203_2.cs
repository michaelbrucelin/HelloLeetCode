using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0203
{
    public class Solution0203_2 : Interface0203
    {
        /// <summary>
        /// TODO：通过指针实现真正的删除链表的中间节点
        /// </summary>
        /// <param name="node"></param>
        public unsafe void DeleteNode(ListNode node)
        {
            ListNode next = node.next;
            node = @next;
        }
    }
}
