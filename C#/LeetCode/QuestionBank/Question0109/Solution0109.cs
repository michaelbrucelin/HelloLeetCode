using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0109
{
    public class Solution0109 : Interface0109
    {
        /// <summary>
        /// 分治
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null) return null;
            if (head.next == null) return new TreeNode(head.val);
            if (head.next.next == null) return new TreeNode(head.val, null, new TreeNode(head.next.val));

            ListNode pslow = new ListNode() { next = head }, pfast = head;
            while (pfast.next != null && pfast.next.next != null)
            {
                pslow = pslow.next;
                pfast = pfast.next.next;
            }

            TreeNode root = new TreeNode(pslow.next.val);
            root.right = SortedListToBST(pslow.next.next);
            pslow.next = null;
            root.left = SortedListToBST(head);

            return root;
        }
    }
}
