using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0129
{
    public class Solution0129_2 : Interface0129
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumNumbers(TreeNode root)
        {
            int result = 0;
            Queue<(TreeNode node, int val)> queue = new Queue<(TreeNode node, int val)>();
            queue.Enqueue((root, 0));
            (TreeNode node, int val) item; int val;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                val = item.val * 10 + item.node.val;
                if (item.node.left == null && item.node.right == null)
                {
                    result += val;
                }
                else
                {
                    if (item.node.left != null) queue.Enqueue((item.node.left, val));
                    if (item.node.right != null) queue.Enqueue((item.node.right, val));
                }
            }

            return result;
        }
    }
}
