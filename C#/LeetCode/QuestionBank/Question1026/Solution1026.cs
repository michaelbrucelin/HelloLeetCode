using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1026
{
    public class Solution1026 : Interface1026
    {
        /// <summary>
        /// 递归，自底向上
        /// 每棵树返回3个值
        ///     1. 树中的最小值
        ///     2. 树中的最大值
        ///     3. 当前树的结果，左子树的结果，右子树的结果 3个值中的最大值
        ///         当前树的结果是根节点与树中最小值的差，与树中最大值的差，二者绝对值的较大的值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxAncestorDiff(TreeNode root)
        {
            return rec(root).diff;  // 题目保证了root不为null
        }

        private (int diff, int max, int min) rec(TreeNode root)
        {
            int diff = 0, max = root.val, min = root.val;
            if (root.left != null)
            {
                var info = rec(root.left);
                max = Math.Max(max, info.max); min = Math.Min(min, info.min); diff = Math.Max(diff, info.diff);
            }
            if (root.right != null)
            {
                var info = rec(root.right);
                max = Math.Max(max, info.max); min = Math.Min(min, info.min); diff = Math.Max(diff, info.diff);
            }
            diff = Math.Max(diff, Math.Abs(root.val - min));
            diff = Math.Max(diff, Math.Abs(root.val - max));

            return (diff, max, min);
        }
    }
}
