using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0700
{
    public class Solution0700_2 : Interface0700
    {
        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode SearchBST(TreeNode root, int val)
        {
            TreeNode ptr = root;
            while (ptr != null) switch (val - ptr.val)
                {
                    case < 0: ptr = ptr.left; break;
                    case > 0: ptr = ptr.right; break;
                    default: return ptr;
                }

            return null;
        }
    }
}
