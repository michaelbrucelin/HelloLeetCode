using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0109
{
    public class Solution0109_err : Interface0109
    {
        /// <summary>
        /// 快慢指针
        /// 构造一个最简单的二叉树，即形状为 /\ 的二叉树
        ///                                 /  \
        ///                                /    \
        /// 
        /// 题目要求的是平衡的二叉搜索树
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null) return null;

            ListNode pslow = head, pfast = head;
            Stack<int> stack = new Stack<int>();
            while (pfast.next != null && pfast.next.next != null)
            {
                stack.Push(pslow.val);
                pslow = pslow.next;
                pfast = pfast.next.next;
            }

            TreeNode root = new TreeNode(pslow.val);
            TreeNode ptr = root;
            while (stack.Count > 0)
            {
                ptr.left = new TreeNode(stack.Pop());
                ptr = ptr.left;
            }
            ptr = root;
            while ((pslow = pslow.next) != null)
            {
                ptr.right = new TreeNode(pslow.val);
                ptr = ptr.right;
            }

            return root;
        }
    }
}
