using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0067
{
    public class Solution0067 : Interface0067
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ExpandBinaryTree(TreeNode root)
        {
            if (root != null)
            {
                if (root.left != null)
                {
                    TreeNode node = new TreeNode(-1, root.left, null);
                    root.left = node;
                    ExpandBinaryTree(node.left);
                }
                if (root.right != null)
                {
                    TreeNode node = new TreeNode(-1, null, root.right);
                    root.right = node;
                    ExpandBinaryTree(node.right);
                }
            }

            return root;
        }
    }
}
