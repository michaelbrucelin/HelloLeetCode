using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0094
{
    public class Solution0094_6 : Interface0094
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            Stack<(bool tag, TreeNode node)> stack = new Stack<(bool, TreeNode)>();  // true:白色, false:灰色
            stack.Push((true, root));
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                if (item.node == null) continue;
                if (item.tag)
                {
                    stack.Push((true, item.node.right));
                    stack.Push((false, item.node));
                    stack.Push((true, item.node.left));
                }
                else
                    result.Add(item.node.val);
            }

            return result;
        }
    }
}
