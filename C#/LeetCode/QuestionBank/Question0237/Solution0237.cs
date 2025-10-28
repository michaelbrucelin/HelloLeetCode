using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0237
{
    public class Solution0237 : Interface0237
    {
        /// <summary>
        /// 脑筋急转弯 + 阅读理解
        /// 不是要删除这个节点，因为根本无法完成，需要将链表后面的值依次迁移一位，再删除链表的最后一个节点
        /// </summary>
        /// <param name="node"></param>
        public void DeleteNode(ListNode node)
        {
            while (node.next.next != null)  // 题目限定node不是链表的最后一个节点
            {
                node.val = node.next.val;
                node = node.next;
            }
            node.val = node.next.val;
            node.next = null;
        }
    }
}
