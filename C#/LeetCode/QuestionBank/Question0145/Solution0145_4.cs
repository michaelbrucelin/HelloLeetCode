using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0145
{
    public class Solution0145_4 : Interface0145
    {
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode ptr = root, prev = null;
            while (ptr != null || stack.Count > 0)
            {
                while (ptr != null) { stack.Push(ptr); ptr = ptr.left; }
                ptr = stack.Pop();
                if (ptr.right == null || ptr.right == prev)
                {
                    result.Add(ptr.val); prev = ptr; ptr = null;  // 处理了ptr，将prev更新为ptr
                }
                else
                {
                    stack.Push(ptr); ptr = ptr.right;
                }
            }

            return result;
        }
    }
}
