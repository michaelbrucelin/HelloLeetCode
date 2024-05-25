using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0044
{
    public class Solution0044_2 : Interface0044
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int NumColor(TreeNode root)
        {
            if (root == null) return 0;

            HashSet<int> result = new HashSet<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                result.Add(item.val);
                if (item.left != null) queue.Enqueue(item.left);
                if (item.right != null) queue.Enqueue(item.right);
            }

            return result.Count;
        }
    }
}
