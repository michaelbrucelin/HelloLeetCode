using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0572
{
    public class Solution0572_2 : Interface0572
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <param name="subRoot"></param>
        /// <returns></returns>
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root.val == subRoot.val && Verify(root, subRoot)) return true;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node.val == subRoot.val && Verify(node, subRoot)) return true;
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            return false;
        }

        private bool Verify(TreeNode node1, TreeNode node2)
        {
            Queue<(TreeNode n1, TreeNode n2)> queue = new Queue<(TreeNode n1, TreeNode n2)>();
            queue.Enqueue((node1, node2));
            while (queue.Count > 0)
            {
                var t = queue.Dequeue();
                if (t.n1 == null && t.n2 == null) continue;
                if (t.n1 == null || t.n2 == null) return false;
                if (t.n1.val != t.n2.val) return false;
                queue.Enqueue((t.n1.left, t.n2.left));
                queue.Enqueue((t.n1.right, t.n2.right));
            }

            return true;
        }
    }
}
