using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0257
{
    public class Solution0257 : Interface0257
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            List<string> paths = new List<string>();

            if (root == null) return paths;
            if (root.left == null && root.right == null)
            {
                paths.Add(root.val.ToString());
            }
            else
            {
                if (root.left != null) dfs(root.left, root.val.ToString(), paths);
                if (root.right != null) dfs(root.right, root.val.ToString(), paths);
            }

            return paths;
        }

        private void dfs(TreeNode node, string path, List<string> paths)
        {
            string _path = $"{path}->{node.val}";
            if (node.left == null && node.right == null)
                paths.Add(_path);
            else
            {
                if (node.left != null) dfs(node.left, _path, paths);
                if (node.right != null) dfs(node.right, _path, paths);
            }
        }
    }
}
