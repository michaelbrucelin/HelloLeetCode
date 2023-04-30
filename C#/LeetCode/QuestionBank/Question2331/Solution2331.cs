using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2331
{
    public class Solution2331 : Interface2331
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool EvaluateTree(TreeNode root)
        {
            if (root.val < 2) return root.val == 1;

            return root.val == 2 ? EvaluateTree(root.left) || EvaluateTree(root.right)
                                 : EvaluateTree(root.left) && EvaluateTree(root.right);
        }
    }
}
