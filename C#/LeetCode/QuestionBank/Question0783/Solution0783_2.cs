using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0783
{
    public class Solution0783_2 : Interface0783
    {
        /// <summary>
        /// DFS
        /// 结果一定出现在每一颗子树的  根与左子树最右侧的值  与  根与右子树最左侧的值  之间
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int MinDiffInBST(TreeNode root)
        {
            return dfs(root).diff;
        }

        private (int left, int right, int diff) dfs(TreeNode node)
        {
            if (node.left == null && node.right == null) return (node.val, node.val, int.MaxValue);
            if (node.left == null)
            {
                var t = dfs(node.right);
                return (node.val, t.right, Math.Min(t.left - node.val, t.diff));
            }
            if (node.right == null)
            {
                var t = dfs(node.left);
                return (t.left, node.val, Math.Min(node.val - t.right, t.diff));
            }
            var tl = dfs(node.left);
            var tr = dfs(node.right);
            int min_diff1 = Math.Min(node.val - tl.right, tr.left - node.val);
            int min_diff2 = Math.Min(tl.diff, tr.diff);
            return (tl.left, tr.right, Math.Min(min_diff1, min_diff2));
        }
    }
}
