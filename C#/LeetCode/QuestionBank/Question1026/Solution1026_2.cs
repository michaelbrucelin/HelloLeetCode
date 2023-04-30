using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1026
{
    public class Solution1026_2 : Interface1026
    {
        /// <summary>
        /// 递归，自顶向下（DFS，回溯）
        /// 遍历管饭项目到各个叶子结点的所有可能的路径，并记录路径中的最大值与最小值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxAncestorDiff(TreeNode root)
        {
            int result = -1;
            dfs(root, root.val, root.val, ref result);  // 题目保证了root不为null

            return result;
        }

        private void dfs(TreeNode root, int max, int min, ref int result)
        {
            max = Math.Max(max, root.val); min = Math.Min(min, root.val);
            if (root.left != null) dfs(root.left, max, min, ref result);
            if (root.right != null) dfs(root.right, max, min, ref result);
            if (root.left == null && root.right == null) result = Math.Max(result, max - min);
        }
    }
}
