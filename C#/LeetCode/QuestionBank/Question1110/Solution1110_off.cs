using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1110
{
    public class Solution1110_off : Interface1110
    {
        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            List<TreeNode> result = new List<TreeNode>();
            HashSet<int> del = new HashSet<int>(to_delete);
            dfs(root, true, del, result);

            return result;
        }

        private TreeNode dfs(TreeNode node, bool isRoot, HashSet<int> del, List<TreeNode> forest)
        {
            bool delete = del.Contains(node.val);
            if (node.left != null) node.left = dfs(node.left, delete, del, forest);
            if (node.right != null) node.right = dfs(node.right, delete, del, forest);

            if (delete)
            {
                return null;
            }
            else
            {
                if (isRoot) forest.Add(node);
                return node;
            }
        }
    }
}
