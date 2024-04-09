using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0174
{
    public class Solution0174 : Interface0174
    {
        /// <summary>
        /// DFS
        /// 类中序遍历，右-根-左 的顺序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public int FindTargetNode(TreeNode root, int cnt)
        {
            int result = -1, order = 1;
            dfs(root, cnt, ref order, ref result);

            return result;
        }

        private void dfs(TreeNode root, int cnt, ref int order, ref int result)
        {
            if (root == null || order > cnt) return;
            dfs(root.right, cnt, ref order, ref result);
            if (order++ == cnt) { result = root.val; return; }
            dfs(root.left, cnt, ref order, ref result);
        }
    }
}
