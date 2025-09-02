using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0099
{
    public class Solution0099 : Interface0099
    {
        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="root"></param>
        public void RecoverTree(TreeNode root)
        {
            List<TreeNode> list = new List<TreeNode>();
            dfs(root);
            int pl = 0, pr = list.Count - 1;
            while (pl < pr && list[pl].val < list[pl + 1].val) pl++;
            while (pr > pl && list[pr].val > list[pr - 1].val) pr--;
            int t = list[pl].val; list[pl].val = list[pr].val; list[pr].val = t;
            return;

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
