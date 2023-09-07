using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0700
{
    public class Solution0700 : Interface0700
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null || root.val == val) return root;

            return val < root.val ? SearchBST(root.left, val) : SearchBST(root.right, val);
        }
    }
}
