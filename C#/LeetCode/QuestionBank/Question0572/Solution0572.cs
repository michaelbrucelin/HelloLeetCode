using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0572
{
    public class Solution0572 : Interface0572
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <param name="subRoot"></param>
        /// <returns></returns>
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root == null) return false;
            if (root.val == subRoot.val && Verify(root, subRoot)) return true;
            if (IsSubtree(root.left, subRoot)) return true;
            if (IsSubtree(root.right, subRoot)) return true;

            return false;
        }

        private bool Verify(TreeNode node1, TreeNode node2)
        {
            if (node1 == null && node2 == null) return true;
            if (node1 == null || node2 == null) return false;
            if (node1.val != node2.val) return false;

            return Verify(node1.left, node2.left) && Verify(node1.right, node2.right);
        }
    }
}
