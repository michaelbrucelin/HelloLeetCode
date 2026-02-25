using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0814
{
    public class Solution0814 : Interface0814
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode PruneTree(TreeNode root)
        {
            if (root == null) return null;

            root.left = PruneTree(root.left);
            root.right = PruneTree(root.right);
            if (root.val == 0 && root.left == null && root.right == null) return null;

            return root;
        }
    }
}
