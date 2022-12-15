using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0102
{
    public class Solution0102_2 : Interface0102
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            dfs(root, result, 0);

            return result;
        }

        private void dfs(TreeNode node, List<IList<int>> buffer, int level)
        {
            // if (node == null) return;  // null不会进来

            if (level == buffer.Count) buffer.Add(new List<int>());
            buffer[level].Add(node.val);
            if (node.left != null) dfs(node.left, buffer, level + 1);
            if (node.right != null) dfs(node.right, buffer, level + 1);
        }
    }
}
