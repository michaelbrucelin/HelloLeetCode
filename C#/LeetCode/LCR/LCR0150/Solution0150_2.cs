using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0150
{
    public class Solution0150_2 : Interface0150
    {
        /// <summary>
        /// DFS，中序遍历
        /// 没有意义，存粹写着玩的
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> DecorateRecord(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            dfs(root, 0, result);

            return result;
        }

        private void dfs(TreeNode root, int level, List<IList<int>> result)
        {
            if (result.Count == level) result.Add(new List<int>());
            result[level].Add(root.val);
            if (root.left != null) dfs(root.left, level + 1, result);
            if (root.right != null) dfs(root.right, level + 1, result);
        }
    }
}
