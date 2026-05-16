using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0044
{
    public class Solution0044_2 : Interface0044
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> LargestValues(TreeNode root)
        {
            List<int> result = [];
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode item; int max, cnt;
            while ((cnt = queue.Count) > 0)
            {
                max = int.MinValue;
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    max = Math.Max(max, item.val);
                    if (item.left != null) queue.Enqueue(item.left);
                    if (item.right != null) queue.Enqueue(item.right);
                }
                result.Add(max);
            }

            return result;
        }
    }
}
