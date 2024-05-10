using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0052
{
    public class Solution0052 : Interface0052
    {
        /// <summary>
        /// DFS 中序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode IncreasingBST(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null)) return root;

            List<TreeNode> inorder = new List<TreeNode>();
            dfs(root, inorder);
            inorder.Add(null);

            int cnt = inorder.Count;
            for (int i = 0; i < cnt - 1; i++)
            {
                inorder[i].left = null; inorder[i].right = inorder[i + 1];
            }

            return inorder[0];
        }

        private void dfs(TreeNode root, List<TreeNode> list)
        {
            if (root != null)
            {
                dfs(root.left, list);
                list.Add(root);
                dfs(root.right, list);
            }
        }
    }
}
