using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0337
{
    public class Solution0337_2 : Interface0337
    {
        /// <summary>
        /// DP
        /// 本质上与Solution0337是一样的，但是dfs返回的不是一个节点的最大值，而是这个节点选与不选两种可能的分别的最大值
        /// 这样做的好处是，每个节点只会被父结点调用一次，而不会被爷爷节点调用，这样就不需要记忆化搜索了
        /// 对于每个节点，只有选与不选两种可能
        ///     选，  结果等于 自身 + 左孩子不选 + 右孩子不选
        ///     不选，结果等于 MAX(左孩子选，左孩子不选) + MAX(右孩子选，右孩子不选)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int Rob(TreeNode root)
        {
            var t = dfs(root);
            return Math.Max(t.choose, t.not);
        }

        private (int choose, int not) dfs(TreeNode node)
        {
            if (node == null) return (0, 0);

            var tl = dfs(node.left); var tr = dfs(node.right);

            return (node.val + tl.not + tr.not, Math.Max(tl.choose, tl.not) + Math.Max(tr.choose, tr.not));
        }
    }
}
