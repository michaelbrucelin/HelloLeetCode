using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1712
{
    public class Solution1712 : Interface1712
    {
        /// <summary>
        /// DFS
        /// 中序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ConvertBiNode(TreeNode root)
        {
            List<TreeNode> list = new List<TreeNode>();
            dfs(root, list);

            list.Add(null);
            for (int i = 0; i < list.Count - 1; i++)
            {
                list[i].left = null; list[i].right = list[i + 1];
            }

            return list[0];
        }

        private void dfs(TreeNode node, List<TreeNode> list)
        {
            if (node == null) return;
            dfs(node.left, list);
            list.Add(node);
            dfs(node.right, list);
        }
    }
}
