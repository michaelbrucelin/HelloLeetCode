using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0150
{
    public class Solution0150 : Interface0150
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> DecorateRecord(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode item; int cnt;
            while ((cnt = queue.Count) > 0)
            {
                List<int> _list = new List<int>();
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    _list.Add(item.val);
                    if (item.left != null) queue.Enqueue(item.left);
                    if (item.right != null) queue.Enqueue(item.right);
                }
                result.Add(_list);
            }

            return result;
        }
    }
}
