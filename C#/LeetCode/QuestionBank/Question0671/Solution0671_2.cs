using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0671
{
    public class Solution0671_2 : Interface0671
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindSecondMinimumValue(TreeNode root)
        {
            int result = int.MaxValue; bool flag = false;
            dfs(root, root.val, ref result, ref flag);

            return flag ? result : -1;
        }

        private void dfs(TreeNode node, int min, ref int result, ref bool flag)
        {
            if (node == null) return;

            if (node.val > min)
            {
                result = Math.Min(result, node.val); flag = true;
            }
            else if (node.left != null)
            {
                dfs(node.left, min, ref result, ref flag);
                dfs(node.right, min, ref result, ref flag);
            }
        }
    }
}
