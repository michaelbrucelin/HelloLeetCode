using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0530
{
    public class Solution0530_3 : Interface0530
    {
        /// <summary>
        /// DFS，中序遍历
        /// 同Solution0530_2，但是没有缓存整个中序遍历的结果
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int GetMinimumDifference(TreeNode root)
        {
            int result = int.MaxValue, prev = -1;  // -1是一个不可能的值
            dfs(root, ref prev, ref result);

            return result;
        }

        private void dfs(TreeNode root, ref int prev, ref int result)
        {
            if (root == null) return;

            dfs(root.left, ref prev, ref result);
            result = prev == -1 ? int.MaxValue : Math.Min(result, root.val - prev);
            prev = root.val;
            dfs(root.right, ref prev, ref result);
        }

        public int GetMinimumDifference2(TreeNode root)
        {
            List<int> list = new List<int>();
            int result = (int)1e5 + 1, last = -(int)1e9 - 1;
            dfs(root);

            return result;

            void dfs(TreeNode node)
            {
                if (node == null) return;
                dfs(node.left);
                result = Math.Min(result, node.val - last); last = node.val;
                dfs(node.right);
            }
        }
    }
}
