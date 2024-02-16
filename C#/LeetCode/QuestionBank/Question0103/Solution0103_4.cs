using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0103
{
    public class Solution0103_4 : Interface0103
    {
        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Stack<(int level, TreeNode node)> stack = new Stack<(int, TreeNode)>();
            int level = 0; TreeNode ptr = root;
            while (ptr != null || stack.Count > 0)
            {
                while (ptr != null)
                {
                    if (level == result.Count) result.Add(new List<int>());
                    result[level].Add(ptr.val); stack.Push((level, ptr)); ptr = ptr.left; level++;
                }
                var item = stack.Pop();
                ptr = item.node.right;
                level = item.level + 1;
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
