using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0938
{
    public class Solution0938_3 : Interface0938
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            int result = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node == null)
                    continue;
                else if (node.val < low)
                    queue.Enqueue(node.right);
                else if (node.val > high)
                    queue.Enqueue(node.left);
                else
                {
                    queue.Enqueue(node.left);
                    result += node.val;
                    queue.Enqueue(node.right);
                }
            }

            return result;
        }
    }
}
