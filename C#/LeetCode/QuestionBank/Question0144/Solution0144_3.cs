using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0144
{
    public class Solution0144_3 : Interface0144
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            dfs(root, result);

            return result;
        }

        private void dfs(TreeNode node, List<int> buffer)
        {
            if (node == null) return;

            buffer.Add(node.val);
            dfs(node.left, buffer);
            dfs(node.right, buffer);
        }
    }
}
