using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0872
{
    public class Solution0872_2 : Interface0872
    {
        /// <summary>
        /// DFS 有返回值
        /// </summary>
        /// <param name="root1"></param>
        /// <param name="root2"></param>
        /// <returns></returns>
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            List<int> leafs1 = dfs(root1), leafs2 = dfs(root2);  // 题目限定root1 root2均不为null
            if (leafs1.Count != leafs2.Count) return false;
            for (int i = 0; i < leafs1.Count; i++) if (leafs1[i] != leafs2[i]) return false;

            return true;
        }

        private List<int> dfs(TreeNode node)
        {
            if (node.left == null && node.right == null)
                return new List<int>() { node.val };
            else if (node.left == null)
                return dfs(node.right);
            else if (node.right == null)
                return dfs(node.left);
            else
            {
                List<int> result = new List<int>();
                result.AddRange(dfs(node.left));
                result.AddRange(dfs(node.right));
                return result;
            }
        }
    }
}
