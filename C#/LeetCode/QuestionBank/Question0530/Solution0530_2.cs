using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0530
{
    public class Solution0530_2 : Interface0530
    {
        /// <summary>
        /// DFS，中序遍历
        /// 二叉搜索树的中序遍历就是升序排序
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int GetMinimumDifference(TreeNode root)
        {
            List<int> list = new List<int>();
            dfs(root, list);

            int result = list[1] - list[0];
            for (int i = 2; i < list.Count; i++) result = Math.Min(result, list[i] - list[i - 1]);
            return result;
        }

        private void dfs(TreeNode root, List<int> list)
        {
            if (root == null) return;
            dfs(root.left, list);
            list.Add(root.val);
            dfs(root.right, list);
        }
    }
}
