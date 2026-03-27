using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0951
{
    public class Solution0951 : Interface0951
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root1"></param>
        /// <param name="root2"></param>
        /// <returns></returns>
        public bool FlipEquiv(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null) return true;
            if (root1 == null || root2 == null) return false;
            if (root1.val != root2.val) return false;

            return (FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right)) ||
                   (FlipEquiv(root1.left, root2.right) && FlipEquiv(root1.right, root2.left));
        }
    }
}
