using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0538
{
    public class Solution0538 : Interface0538
    {
        /// <summary>
        /// 中序遍历 + 栈
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ConvertBST(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            dfs(root);

            int sum = 0;
            TreeNode ptr;
            while (stack.Count > 0)
            {
                ptr = stack.Pop();
                ptr.val += sum;
                sum = ptr.val;
            }
            return root;

            void dfs(TreeNode node)
            {
                if (node == null) return;
                dfs(node.left);
                stack.Push(node);
                dfs(node.right);
            }
        }
    }
}
