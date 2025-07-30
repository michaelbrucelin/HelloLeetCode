using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0114
{
    public class Solution0114 : Interface0114
    {
        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <param name="root"></param>
        public void Flatten(TreeNode root)
        {
            if (root == null) return;
            if (root.left == null && root.right == null) return;

            List<TreeNode> list = new List<TreeNode>();
            dfs(root);
            for (int i = 0; i < list.Count - 1; i++) { list[i].left = null; list[i].right = list[i + 1]; }
            list[^1].left = list[^1].right = null;
            return;

            void dfs(TreeNode node)
            {
                if (node == null) return;
                list.Add(node);
                dfs(node.left);
                dfs(node.right);
            }
        }
    }
}
