using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0099
{
    public class Solution0099_3 : Interface0099
    {
        /// <summary>
        /// 进阶，将空间复杂度降为O(1)
        /// 逻辑与Solution0099完全一样，只是取消了List<TreeNode>
        /// 中序遍历找到较小的错误的TreeNode，镜像中序（右根左）遍历找到较大的错误的TreeNode
        /// </summary>
        /// <param name="root"></param>
        public void RecoverTree(TreeNode root)
        {
            TreeNode node1 = null, node2 = null, last;
            last = new TreeNode(int.MinValue); dfs1(root);
            last = new TreeNode(int.MaxValue); dfs2(root);
            int t = node1.val; node1.val = node2.val; node2.val = t;
            return;

            void dfs1(TreeNode node)
            {
                if (node1 != null || node == null) return;
                dfs1(node.left);
                if (node.val < last.val) { node1 = last; return; }
                last = node;
                dfs1(node.right);
            }

            void dfs2(TreeNode node)
            {
                if (node2 != null || node == null) return;
                dfs2(node.right);
                if (node.val > last.val) { node2 = last; return; }
                last = node;
                dfs2(node.left);
            }
        }
    }
}
