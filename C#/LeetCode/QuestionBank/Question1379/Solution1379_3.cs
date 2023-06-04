using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1379
{
    public class Solution1379_3 : Interface1379
    {
        /// <summary>
        /// DFS
        /// 进阶的解法，同时遍历两棵树
        /// </summary>
        /// <param name="original"></param>
        /// <param name="cloned"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            if (original == null || original == target) return cloned;
            TreeNode result;
            result = GetTargetCopy(original.left, cloned.left, target);
            if (result != null) return result;
            result = GetTargetCopy(original.right, cloned.right, target);
            return result;
        }
    }
}
