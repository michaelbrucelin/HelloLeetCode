using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0103
{
    public class Solution0103_3 : Interface0103
    {
        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Stack<(int level, TreeNode node)> stack = new Stack<(int, TreeNode)>();
            int level = 0; TreeNode ptr = root;
            while (ptr != null)
            {
                if (level == result.Count) result.Add(new List<int>());
                result[level].Add(ptr.val);
                if (ptr.left != null)
                {
                    if (ptr.right != null) stack.Push((level + 1, ptr.right));
                    ptr = ptr.left;
                    level++;
                }
                else
                {
                    if (ptr.right != null) { ptr = ptr.right; level++; }
                    else if (stack.Count > 0) { var item = stack.Pop(); ptr = item.node; level = item.level; }
                    else break;
                }
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
