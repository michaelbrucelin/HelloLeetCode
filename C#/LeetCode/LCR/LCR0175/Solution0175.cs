using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0175
{
    public class Solution0175 : Interface0175
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int CalculateDepth(TreeNode root)
        {
            if (root == null) return 0;

            int result = 0, cnt;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode item;
            while ((cnt = queue.Count) > 0)
            {
                result++;
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    if (item.left != null) queue.Enqueue(item.left);
                    if (item.right != null) queue.Enqueue(item.right);
                }
            }

            return result;
        }
    }
}
