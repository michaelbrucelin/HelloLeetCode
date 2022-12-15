using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0094
{
    public class Solution0094_3 : Interface0094
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            dfs(root, result);

            return result;
        }

        private void dfs(TreeNode node, List<int> buffer)
        {
            // if (node == null) return;  // null不会进来

            if (node.left != null) dfs(node.left, buffer);
            buffer.Add(node.val);
            if (node.right != null) dfs(node.right, buffer);
        }
    }
}
