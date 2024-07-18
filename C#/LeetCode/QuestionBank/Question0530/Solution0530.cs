using LeetCode.QuestionBank.Question0855;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0530
{
    public class Solution0530 : Interface0530
    {
        /// <summary>
        /// DFS
        /// 最小插值一定是下面两种情况之一
        ///     根 - 左子树的最右边叶子
        ///     右子树的最左边叶子 - 根
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int GetMinimumDifference(TreeNode root)
        {
            if (root == null) return int.MaxValue;
            int r_left = int.MaxValue, r_right = int.MaxValue, r_son;
            if (root.left != null)
            {
                TreeNode ptr = root.left; while (ptr.right != null) ptr = ptr.right;
                r_left = root.val - ptr.val;
            }
            if (root.right != null)
            {
                TreeNode ptr = root.right; while (ptr.left != null) ptr = ptr.left;
                r_right = ptr.val - root.val;
            }
            r_son = Math.Min(GetMinimumDifference(root.left), GetMinimumDifference(root.right));

            return Math.Min(Math.Min(r_left, r_right), r_son);
        }
    }
}
