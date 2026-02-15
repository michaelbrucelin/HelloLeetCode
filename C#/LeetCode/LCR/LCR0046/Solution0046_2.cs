using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0046
{
    public class Solution0046_2 : Interface0046
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> RightSideView(TreeNode root)
        {
            if (root == null) return [];

            List<int> result = [];
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int cnt; TreeNode item;
            while ((cnt = queue.Count) > 0)
            {
                item = queue.Dequeue();
                result.Add(item.val);
                if (item.right != null) queue.Enqueue(item.right);
                if (item.left != null) queue.Enqueue(item.left);
                for (int i = 1; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    if (item.right != null) queue.Enqueue(item.right);
                    if (item.left != null) queue.Enqueue(item.left);
                }
            }

            return result;
        }
    }
}
