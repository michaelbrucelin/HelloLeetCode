using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1123
{
    public class Solution1123_3 : Interface1123
    {
        /// <summary>
        /// 递归
        /// 1. DFS计算每个节点的深度
        /// 2. 对于节点root，如果左子树与右子树深度相同，则返回root，否则递归更深的子树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode LcaDeepestLeaves(TreeNode root)
        {
            int[] depth = new int[1001];
            dfs(root);
            return rec(root);

            TreeNode rec(TreeNode node)
            {
                if (node == null) return null;
                if (node.left == null && node.right == null) return node;
                if (node.left == null) return rec(node.right);
                if (node.right == null) return rec(node.left);

                switch (depth[node.left.val] - depth[node.right.val])
                {
                    case > 0: return rec(node.left);
                    case < 0: return rec(node.right);
                    default: return node;
                }
            }

            void dfs(TreeNode node)
            {
                if (node == null) return;

                int lh = 0, rh = 0;
                if (node.left != null)
                {
                    if (depth[node.left.val] == 0) dfs(node.left);
                    lh = depth[node.left.val];
                }
                if (node.right != null)
                {
                    if (depth[node.right.val] == 0) dfs(node.right);
                    rh = depth[node.right.val];
                }

                depth[node.val] = Math.Max(lh, rh) + 1;
            }
        }
    }
}
