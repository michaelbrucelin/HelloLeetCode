using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0515
{
    public class Solution0515_2 : Interface0515
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> LargestValues(TreeNode root)
        {
            if (root == null) return [];

            List<int> result = [];
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int cnt, max; TreeNode item;
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
