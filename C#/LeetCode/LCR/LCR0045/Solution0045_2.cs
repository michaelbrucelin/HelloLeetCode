using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0045
{
    public class Solution0045_2 : Interface0045
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindBottomLeftValue(TreeNode root)
        {
            int result = root.val;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int cnt; TreeNode item;
            while ((cnt = queue.Count) > 0)
            {
                item = queue.Dequeue();
                result = item.val;
                if (item.left != null) queue.Enqueue(item.left);
                if (item.right != null) queue.Enqueue(item.right);

                for (int i = 1; i < cnt; i++)
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
