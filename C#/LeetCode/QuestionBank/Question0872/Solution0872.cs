using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0872
{
    public class Solution0872 : Interface0872
    {
        /// <summary>
        /// DFS 无返回值
        /// </summary>
        /// <param name="root1"></param>
        /// <param name="root2"></param>
        /// <returns></returns>
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            List<int> leafs1 = new List<int>(), leafs2 = new List<int>();  // 题目限定root1 root2均不为null
            dfs(root1, leafs1);
            dfs(root2, leafs2);
            if (leafs1.Count != leafs2.Count) return false;
            for (int i = 0; i < leafs1.Count; i++) if (leafs1[i] != leafs2[i]) return false;

            return true;
        }

        private void dfs(TreeNode node, List<int> leafs)
        {
            if (node.left == null && node.right == null)
                leafs.Add(node.val);
            else if (node.left == null)
                dfs(node.right, leafs);
            else if (node.right == null)
                dfs(node.left, leafs);
            else
            {
                dfs(node.left, leafs);
                dfs(node.right, leafs);
            }
        }
    }
}
