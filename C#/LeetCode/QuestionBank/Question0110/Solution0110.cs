using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0110
{
    public class Solution0110 : Interface0110
    {
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;

            int left_depth = TreeDepth(root.left);
            int right_depth = TreeDepth(root.right);
            if (Math.Abs(left_depth - right_depth) > 1) return false;

            return IsBalanced(root.left) && IsBalanced(root.right);
        }

        private int TreeDepth(TreeNode root)
        {
            if (root == null) return 0;

            int left_depth = TreeDepth(root.left);
            int right_depth = TreeDepth(root.right);
            return Math.Max(left_depth, right_depth) + 1;
        }
    }
}
