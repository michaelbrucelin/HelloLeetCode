using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0101
{
    public class Solution0101_3 : Interface0101
    {
        /// <summary>
        /// 迭代
        /// 本质上就是同时遍历根的左子树与根的右子树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            if (root.left == null && root.right == null) return true;
            if (root.left == null || root.right == null) return false;

            Queue<TreeNode> queue_left = new Queue<TreeNode>(); queue_left.Enqueue(root.left);
            Queue<TreeNode> queue_right = new Queue<TreeNode>(); queue_right.Enqueue(root.right);
            int cnt; while ((cnt = queue_left.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode left = queue_left.Dequeue(), right = queue_right.Dequeue();
                    if (left.val != right.val) return false;
                    if ((left.left == null && right.right != null) || (left.left != null && right.right == null)) return false;
                    if (left.left != null && right.right != null)
                    {
                        queue_left.Enqueue(left.left); queue_right.Enqueue(right.right);
                    }
                    if ((left.right == null && right.left != null) || (left.right != null && right.left == null)) return false;
                    if (left.right != null && right.left != null)
                    {
                        queue_left.Enqueue(left.right); queue_right.Enqueue(right.left);
                    }
                }
            }

            return true;
        }
    }
}
