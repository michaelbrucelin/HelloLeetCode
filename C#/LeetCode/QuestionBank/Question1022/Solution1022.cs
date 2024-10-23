using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1022
{
    public class Solution1022 : Interface1022
    {
        /// <summary>
        /// DFS，无返回值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumRootToLeaf(TreeNode root)
        {
            if (root == null) return 0;

            int result = 0;
            dfs(root, 0, ref result);

            return result;
        }

        private void dfs(TreeNode node, int curr, ref int result)
        {
            curr = (curr << 1) | node.val;
            if (node.left == null && node.right == null) result += curr;
            else if (node.left == null) dfs(node.right, curr, ref result);
            else if (node.right == null) dfs(node.left, curr, ref result);
            else
            {
                dfs(node.left, curr, ref result);
                dfs(node.right, curr, ref result);
            }
        }

        public int SumRootToLeaf2(TreeNode root)
        {
            int result = 0;
            dfs(root, root.val);

            return result;

            void dfs(TreeNode node, int curr)
            {
                if (node.left == null && node.right == null)
                {
                    result += curr;
                }
                else
                {
                    curr <<= 1;
                    if (node.left != null) dfs(node.left, curr + node.left.val);
                    if (node.right != null) dfs(node.right, curr + node.right.val);
                }
            }
        }
    }
}
