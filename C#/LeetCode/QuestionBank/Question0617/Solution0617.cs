using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0617
{
    public class Solution0617 : Interface0617
    {
        /// <summary>
        /// DFS
        /// 前序遍历
        /// </summary>
        /// <param name="root1"></param>
        /// <param name="root2"></param>
        /// <returns></returns>
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null) return null;

            TreeNode node = null;
            if (root1 != null && root2 != null)
            {
                node = new TreeNode(root1.val + root2.val);
                node.left = MergeTrees(root1.left, root2.left);
                node.right = MergeTrees(root1.right, root2.right);
            }
            else if (root1 != null) node = root1;
            else if (root2 != null) node = root2;

            return node;
        }

        /// <summary>
        /// DFS
        /// 中序遍历
        /// </summary>
        /// <param name="root1"></param>
        /// <param name="root2"></param>
        /// <returns></returns>
        public TreeNode MergeTrees2(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null) return null;

            TreeNode node = null;
            if (root1 != null && root2 != null)
            {
                node = new TreeNode();
                node.left = MergeTrees2(root1.left, root2.left);
                node.val = root1.val + root2.val;
                node.right = MergeTrees2(root1.right, root2.right);
            }
            else if (root1 != null) node = root1;
            else if (root2 != null) node = root2;

            return node;
        }

        /// <summary>
        /// DFS
        /// 后序遍历
        /// </summary>
        /// <param name="root1"></param>
        /// <param name="root2"></param>
        /// <returns></returns>
        public TreeNode MergeTrees3(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null) return null;

            TreeNode node = null;
            if (root1 != null && root2 != null)
            {
                node = new TreeNode();
                node.left = MergeTrees3(root1.left, root2.left);
                node.right = MergeTrees3(root1.right, root2.right);
                node.val = root1.val + root2.val;
            }
            else if (root1 != null) node = root1;
            else if (root2 != null) node = root2;

            return node;
        }
    }
}
