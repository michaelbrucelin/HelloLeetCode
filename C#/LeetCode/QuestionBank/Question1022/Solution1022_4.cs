using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1022
{
    public class Solution1022_4 : Interface1022
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumRootToLeaf(TreeNode root)
        {
            return dfs(root, 0);

            int dfs(TreeNode node, int curr)
            {
                curr <<= 1;
                curr += node.val;

                if (node.left == null && node.right == null) return curr;

                return (node.left != null ? dfs(node.left, curr) : 0) + (node.right != null ? dfs(node.right, curr) : 0);
            }
        }
    }
}
