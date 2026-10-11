using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0153
{
    public class Solution0153 : Interface0153
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> PathTarget(TreeNode root, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            dfs(root, [], 0);

            return result;

            void dfs(TreeNode node, List<int> list, int sum)
            {
                list.Add(node.val);
                sum += node.val;

                switch ((node.left, node.right))
                {
                    case (null, null):
                        if (sum == target) result.Add(list);
                        break;
                    case (_, null):
                        dfs(node.left, list, sum);
                        break;
                    case (null, _):
                        dfs(node.right, list, sum);
                        break;
                    case (_, _):
                        List<int> _list = [.. list];
                        dfs(node.left, _list, sum);
                        dfs(node.right, list, sum);
                        break;
                }
            }
        }
    }
}
