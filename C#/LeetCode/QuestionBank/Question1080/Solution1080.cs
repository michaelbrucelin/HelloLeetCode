using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1080
{
    public class Solution1080 : Interface1080
    {
        /// <summary>
        /// dfs
        /// </summary>
        /// <param name="root"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public TreeNode SufficientSubset(TreeNode root, int limit)
        {
            HashSet<TreeNode> set_no = new HashSet<TreeNode>();
            List<TreeNode> path = new List<TreeNode>() { root };
            Insufficient_DFS(path, root.val, limit, set_no);
            if (!set_no.Contains(root)) return null;

            dfs(root, set_no);
            return root;
        }

        private void dfs(TreeNode root, HashSet<TreeNode> set_no)
        {
            if (root.left != null)
            {
                if (!set_no.Contains(root.left)) root.left = null; else dfs(root.left, set_no);
            }
            if (root.right != null)
            {
                if (!set_no.Contains(root.right)) root.right = null; else dfs(root.right, set_no);
            }
        }

        private void Insufficient_DFS(List<TreeNode> path, int sum, int limit, HashSet<TreeNode> set_no)
        {
            TreeNode node = path[^1];
            if (node.left == null && node.right == null)
            {
                if (sum >= limit) for (int i = 0; i < path.Count; i++) set_no.Add(path[i]);
            }
            else
            {
                if (node.left != null)
                {
                    List<TreeNode> _path = new List<TreeNode>(path) { node.left };
                    int _sum = sum + node.left.val;
                    Insufficient_DFS(_path, _sum, limit, set_no);
                }
                if (node.right != null)
                {
                    List<TreeNode> _path = new List<TreeNode>(path) { node.right };
                    int _sum = sum + node.right.val;
                    Insufficient_DFS(_path, _sum, limit, set_no);
                }
            }
        }
    }
}
