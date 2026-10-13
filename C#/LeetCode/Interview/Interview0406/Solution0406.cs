using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0406
{
    public class Solution0406 : Interface0406
    {
        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            List<TreeNode> list = new List<TreeNode>();
            dfs(root);
            list.Add(null);
            for (int i = 0, cnt = list.Count; i < cnt; i++) if (list[i] == p) return list[i + 1];
            return null;

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
