using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1022
{
    public class Solution1022_2 : Interface1022
    {
        /// <summary>
        /// DFS，有返回值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumRootToLeaf(TreeNode root)
        {
            if (root == null) return 0;

            return dfs(root, 0);
        }

        private int dfs(TreeNode node, int curr)
        {
            curr = (curr << 1) | node.val;
            if (node.left == null && node.right == null) return curr;
            else if (node.left == null) return dfs(node.right, curr);
            else if (node.right == null) return dfs(node.left, curr);
            else return dfs(node.left, curr) + dfs(node.right, curr);
        }

        public int SumRootToLeaf2(TreeNode root)
        {
            return dfs(root, 0);

            int dfs(TreeNode node, int curr)
            {
                curr = (curr << 1) | node.val;
                if (node.left == null && node.right == null)
                {
                    return curr;
                }
                else
                {
                    if (node.left == null) return dfs(node.right, curr);
                    if (node.right == null) return dfs(node.left, curr);
                    return dfs(node.left, curr) + dfs(node.right, curr);
                }
            }
        }
    }
}
