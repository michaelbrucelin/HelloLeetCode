using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0054
{
    public class Solution0054 : Interface0054
    {
        /// <summary>
        /// 中序遍历
        /// 将树中序遍历保存在列表中，然后反序遍历累加值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ConvertBST(TreeNode root)
        {
            List<TreeNode> list = new List<TreeNode>();
            dfs(root);

            for (int i = list.Count - 2; i >= 0; i--) list[i].val += list[i + 1].val;
            return root;

            void dfs(TreeNode node)
            {
                if (node == null) return;
                dfs(node.left);
                list.Add(node);
                dfs(node.right);
            }
        }
    }
}
