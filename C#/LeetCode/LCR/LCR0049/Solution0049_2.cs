using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0049
{
    public class Solution0049_2 : Interface0049
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumNumbers(TreeNode root)
        {
            if (root == null) return 0;

            int result = 0;
            Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();
            queue.Enqueue((root, root.val));
            TreeNode node; int val;
            while (queue.Count > 0)
            {
                (node, val) = queue.Dequeue();
                if (node.left == null && node.right == null)
                {
                    result += val;
                }
                else
                {
                    if (node.left != null) queue.Enqueue((node.left, val * 10 + node.left.val));
                    if (node.right != null) queue.Enqueue((node.right, val * 10 + node.right.val));
                }
            }

            return result;
        }
    }
}
