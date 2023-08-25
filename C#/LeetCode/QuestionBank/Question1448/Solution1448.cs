using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1448
{
    public class Solution1448 : Interface1448
    {
        /// <summary>
        /// dfs，无返回值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int GoodNodes(TreeNode root)
        {
            int result = 0;
            dfs(root, -10001, ref result);  // -10001是哨兵

            return result;
        }

        private void dfs(TreeNode node, int max, ref int result)
        {
            if (node == null) return;
            if (node.val >= max)
            {
                result++; max = node.val;
            }
            dfs(node.left, max, ref result);
            dfs(node.right, max, ref result);
        }

        /// <summary>
        /// dfs，有返回值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int GoodNodes2(TreeNode root)
        {
            return dfs2(root, -10001);  // -10001是哨兵
        }

        private int dfs2(TreeNode node, int max)
        {
            if (node == null) return 0;
            if (node.val >= max)
            {
                max = node.val;
                return dfs2(node.left, max) + dfs2(node.right, max) + 1;
            }
            else
            {
                return dfs2(node.left, max) + dfs2(node.right, max);
            }
        }
    }
}
