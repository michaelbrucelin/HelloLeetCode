using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0044
{
    public class Solution0044 : Interface0044
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int NumColor(TreeNode root)
        {
            if (root == null) return 0;

            HashSet<int> result = new HashSet<int>();
            dfs(root, result);

            return result.Count;
        }

        private void dfs(TreeNode root, HashSet<int> result)
        {
            if (root == null) return;

            result.Add(root.val);
            dfs(root.left, result);
            dfs(root.right, result);
        }

        /// <summary>
        /// 逻辑同NumColor()，试一下在函数内写另一个函数，有C语言内联函数的味道
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int NumColor2(TreeNode root)
        {
            if (root == null) return 0;

            HashSet<int> result = new HashSet<int>();
            void dfs(TreeNode root)
            {
                if (root == null) return;

                result.Add(root.val);
                dfs(root.left);
                dfs(root.right);
            }
            dfs(root);

            return result.Count;
        }
    }
}
