using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0783
{
    public class Solution0783 : Interface0783
    {
        /// <summary>
        /// DFS
        /// 二叉搜索树的中序序列时升序排列的
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int MinDiffInBST(TreeNode root)
        {
            List<int> tree = new List<int>();
            dfs(root, tree);

            int result = tree[1] - tree[0];
            for (int i = 2; i < tree.Count; i++) result = Math.Min(result, tree[i] - tree[i - 1]);

            return result;
        }

        private void dfs(TreeNode node, List<int> tree)
        {
            if (node == null) return;
            dfs(node.left, tree);
            tree.Add(node.val);
            dfs(node.right, tree);
        }
    }
}
