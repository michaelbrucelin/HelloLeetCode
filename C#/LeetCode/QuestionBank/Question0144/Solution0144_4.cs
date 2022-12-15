using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0144
{
    public class Solution0144_4 : Interface0144
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode ptr = root;
            while (ptr != null || stack.Count > 0)
            {
                while (ptr != null) { result.Add(ptr.val); stack.Push(ptr); ptr = ptr.left; }
                ptr = stack.Pop();
                ptr = ptr.right;
            }

            return result;
        }
    }
}
