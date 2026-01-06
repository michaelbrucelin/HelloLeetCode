using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1161
{
    public class Solution1161 : Interface1161
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxLevelSum(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int cnt, sum = root.val, level = 1, _sum, _level = 0; TreeNode item;
            while ((cnt = queue.Count) > 0)
            {
                _sum = 0; _level++;
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    _sum += item.val;
                    if (item.left != null) queue.Enqueue(item.left);
                    if (item.right != null) queue.Enqueue(item.right);
                }
                if (_sum > sum) (sum, level) = (_sum, _level);
            }

            return level;
        }
    }
}
