using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0110
{
    public class Solution0110_3 : Interface0110
    {
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;

            return TreeHeight(root) >= 0;
        }

        private int TreeHeight(TreeNode node)
        {
            if (node == null) return 0;

            int left_height = TreeHeight(node.left);
            int right_height = TreeHeight(node.right);
            if (left_height == -1 || right_height == -1 || Math.Abs(left_height - right_height) > 1)
                return -1;
            else
                return Math.Max(left_height, right_height) + 1;
        }
    }
}
