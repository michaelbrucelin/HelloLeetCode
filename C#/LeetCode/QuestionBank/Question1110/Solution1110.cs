using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1110
{
    public class Solution1110 : Interface1110
    {
        /// <summary>
        /// dfs（递归） + 双指针
        /// 1. 递归的时候，同时传递遍历的结点与其父结点
        /// 2.1. 如果当前结点在to_delete中
        ///         父结点对应的指针置为null
        ///         递归当前结点的左右孩子结点
        /// 2.2. 如果当前结点不在to_delete中
        ///         如果父结点在to_delete中，将当前结点放入结果中
        ///         递归当前结点的左右孩子结点
        /// </summary>
        /// <param name="root"></param>
        /// <param name="to_delete"></param>
        /// <returns></returns>
        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            List<TreeNode> result = new List<TreeNode>();
            HashSet<int> del = new HashSet<int>(to_delete) { -1 };
            TreeNode dummy = new TreeNode(-1);
            dfs(root, dummy, true, del, result);

            return result;
        }

        private void dfs(TreeNode node, TreeNode parent, bool left, HashSet<int> del, List<TreeNode> forest)
        {
            if (del.Contains(node.val))
            {
                if (left) parent.left = null; else parent.right = null;
            }
            else  // if (!del.Contains(node))
            {
                if (del.Contains(parent.val)) forest.Add(node);
            }

            if (node.left != null) dfs(node.left, node, true, del, forest);
            if (node.right != null) dfs(node.right, node, false, del, forest);
        }
    }
}
