using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0865
{
    public class Solution0865 : Interface0865
    {
        /// <summary>
        /// 两轮DFS
        /// DFS，计算每个子树的高度
        /// DFS，如果node的左右子树一样高，node就是结果，否则递归更深的子树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode SubtreeWithAllDeepest(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null)) return root;
            Dictionary<TreeNode, int> map = new Dictionary<TreeNode, int>();
            dfs1(root);
            return dfs2(root);

            int dfs1(TreeNode node)
            {
                if (node == null) return 0;
                int heightl = dfs1(node.left);
                int heightr = dfs1(node.right);
                int height = Math.Max(heightl, heightr) + 1;
                map.Add(node, height);
                return height;
            }

            TreeNode dfs2(TreeNode node)
            {
                int heightl = node.left != null ? map[node.left] : 0;
                int heightr = node.right != null ? map[node.right] : 0;
                switch (heightl - heightr)
                {
                    case > 0: return dfs2(node.left);
                    case < 0: return dfs2(node.right);
                    default: return node;
                }
            }
        }

        /// <summary>
        /// 逻辑与SubtreeWithAllDeepest()完全相同，改为一轮DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode SubtreeWithAllDeepest2(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null)) return root;
            return dfs(root).node;

            (TreeNode node, int height) dfs(TreeNode node)
            {
                if (node == null) return (null, 0);
                (TreeNode node, int height) infol = dfs(node.left);
                (TreeNode node, int height) infor = dfs(node.right);
                int height = Math.Max(infol.height, infor.height) + 1;
                switch (infol.height - infor.height)
                {
                    case > 0: return (infol.node, height);
                    case < 0: return (infor.node, height);
                    default: return (node, height);
                }
            }
        }
    }
}
