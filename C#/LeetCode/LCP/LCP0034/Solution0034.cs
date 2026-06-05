using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0034
{
    public class Solution0034 : Interface0034
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxValue(TreeNode root, int k)
        {
            Dictionary<(TreeNode, int), int> memory = new Dictionary<(TreeNode, int), int>();
            return dfs(root, k);

            int dfs(TreeNode node, int _k)
            {
                if (node == null) return 0;
                if (memory.TryGetValue((node, _k), out int value)) return value;

                int result = dfs(node.left, k) + dfs(node.right, k);
                if (_k > 0)
                {
                    result = Math.Max(result, node.val);
                    for (int i = 0, j = _k - 1; j >= 0; i++, j--) result = Math.Max(result, node.val + dfs(node.left, i) + dfs(node.right, j));
                }

                memory.Add((node, _k), result);
                return result;
            }
        }
    }
}
