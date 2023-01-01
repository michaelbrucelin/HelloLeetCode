using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0101
{
    public class Solution0101_2 : Interface0101
    {
        /// <summary>
        /// 递归
        /// 本质上就是同时遍历根的左子树与根的右子树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            return dfs(root.left, root.right);
        }

        private bool dfs(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;
            if (left.val != right.val) return false;
            if (!dfs(left.left, right.right))
                return false;
            else
                return dfs(left.right, right.left);
        }
    }
}
