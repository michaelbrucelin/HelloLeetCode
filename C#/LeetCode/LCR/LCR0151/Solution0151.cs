using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0151
{
    public class Solution0151 : Interface0151
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> DecorateRecord(TreeNode root)
        {
            if (root == null) return [];

            IList<IList<int>> result = new List<IList<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode item;
            while (queue.Count > 0)
            {
                result.Add(new List<int>());
                for (int i = queue.Count; i > 0; i--)
                {
                    result[^1].Add((item = queue.Dequeue()).val);
                    if (item.left != null) queue.Enqueue(item.left);
                    if (item.right != null) queue.Enqueue(item.right);
                }
            }

            for (int i = 1; i < result.Count; i += 2) for (int l = 0, r = result[i].Count - 1; l < r; l++, r--)
                {
                    (result[i][l], result[i][r]) = (result[i][r], result[i][l]);
                }
            return result;
        }
    }
}
