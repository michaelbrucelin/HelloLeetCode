using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0094
{
    public class Solution0094_5 : Interface0094
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            TreeNode ptr = root, pre;
            while (ptr != null)
            {
                if (ptr.left == null) { result.Add(ptr.val); ptr = ptr.right; }
                else
                {
                    pre = ptr.left; while (pre.right != null && pre.right != ptr) pre = pre.right;
                    if (pre.right == null)
                    {
                        pre.right = ptr; ptr = ptr.left;
                    }
                    else
                    {
                        pre.right = null; result.Add(ptr.val); ptr = ptr.right;
                    }
                }
            }

            return result;
        }
    }
}
