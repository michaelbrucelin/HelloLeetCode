using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0337
{
    public class Solution0337 : Interface0337
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 一个节点，只有选择与不选择两种可能，选与不选
        ///     选，  结果是当前节点的值与4个（至多4个）孙子节点结果的和
        ///     不选，结果是2个（至多2个）子节点结果的和
        /// 这里面每个节点会被父结点调用一次，也会被爷爷节点调用一次，所以记忆化搜索是有意义的
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int Rob(TreeNode root)
        {
            return dfs(root, new Dictionary<TreeNode, int>());
        }

        private int dfs(TreeNode node, Dictionary<TreeNode, int> cache)
        {
            if (node == null) return 0;
            if (cache.ContainsKey(node)) return cache[node];

            int r0 = node.val, r1 = 0;  // r0，选择，r1，不选择
            if (node.left != null)
            {
                r0 += dfs(node.left.left, cache) + dfs(node.left.right, cache);
                r1 += dfs(node.left, cache);
            }
            if (node.right != null)
            {
                r0 += dfs(node.right.left, cache) + dfs(node.right.right, cache);
                r1 += dfs(node.right, cache);
            }
            r0 = Math.Max(r0, r1);
            cache.Add(node, r0);

            return r0;
        }
    }
}
