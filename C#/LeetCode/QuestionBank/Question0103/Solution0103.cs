using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0103
{
    public class Solution0103 : Interface0103
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int cnt; TreeNode node;
            while ((cnt = queue.Count()) > 0)
            {
                List<int> list = new List<int>();
                for (int i = 0; i < cnt; i++)
                {
                    node = queue.Dequeue();
                    list.Add(node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                result.Add(list);
            }

            for (int i = 1; i < result.Count; i += 2)
            {
                // result[i] = result[i].Reverse().ToList();
                for (int j = 0, k = result[i].Count - 1, t; j < k; j++, k--)
                {
                    t = result[i][j]; result[i][j] = result[i][k]; result[i][k] = t;
                }
            }

            return result;
        }
    }
}
