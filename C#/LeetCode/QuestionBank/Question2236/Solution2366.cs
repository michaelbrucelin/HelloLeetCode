using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2236
{
    public class Solution2366 : Interface2366
    {
        public bool CheckTree(TreeNode root)
        {
            return root.val == root.left.val + root.right.val;
        }
    }
}
