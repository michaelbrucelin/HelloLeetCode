using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0094
{
    public class Solution0094_4 : Interface0094
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode ptr = root;
            while (ptr != null || stack.Count > 0)
            {
                while (ptr != null) { stack.Push(ptr); ptr = ptr.left; }
                ptr = stack.Pop();
                result.Add(ptr.val);
                ptr = ptr.right;
            }

            return result;
        }
    }
}
