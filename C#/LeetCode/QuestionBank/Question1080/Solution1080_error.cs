using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1080
{
    public class Solution1080_error : Interface1080
    {
        /// <summary>
        /// 递归
        /// 自顶向下
        /// 
        /// 题目理解错误了，验证的不是某个顶点到其叶子节点之间所有节点的值的和
        ///                 而是途径某个节点的根到叶子节点之间所有节点的值的和
        /// </summary>
        /// <param name="root"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public TreeNode SufficientSubset(TreeNode root, int limit)
        {
            if (IsInsufficient(root, limit)) return null;
            if (root.left != null) rec(root.left, limit);
            if (root.right != null) rec(root.right, limit);

            return root;
        }

        private void rec(TreeNode root, int limit)
        {
            if (root.left != null)
            {
                if (IsInsufficient(root.left, limit)) root.left = null; else rec(root.left, limit);
            }
            if (root.right != null)
            {
                if (IsInsufficient(root.right, limit)) root.right = null; else rec(root.right, limit);
            }
        }

        private bool IsInsufficient(TreeNode root, int limit)
        {
            Queue<(TreeNode node, int sum)> queue = new Queue<(TreeNode node, int sum)>();
            queue.Enqueue((root, root.val));
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    var t = queue.Dequeue();
                    if (t.node.left == null && t.node.right == null)
                    {
                        if (t.sum >= limit) return false;
                    }
                    else
                    {
                        if (t.node.left != null) queue.Enqueue((t.node.left, t.sum + t.node.left.val));
                        if (t.node.right != null) queue.Enqueue((t.node.right, t.sum + t.node.right.val));
                    }
                }
            }

            return true;
        }
    }
}
