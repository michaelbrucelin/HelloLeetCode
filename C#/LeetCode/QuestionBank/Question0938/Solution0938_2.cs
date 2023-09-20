using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0938
{
    public class Solution0938_2 : Interface0938
    {
        /// <summary>
        /// 同Solution0938，有返回值版
        /// </summary>
        /// <param name="root"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            if (root == null) return 0;
            if (root.val < low) return RangeSumBST(root.right, low, high);
            if (root.val > high) return RangeSumBST(root.left, low, high);
            return root.val
                   + RangeSumBST(root.left, low, high)
                   + RangeSumBST(root.right, low, high);
        }
    }
}
