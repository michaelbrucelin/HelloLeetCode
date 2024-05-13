using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0056
{
    public class Solution0056_2 : Interface0056
    {
        /// <summary>
        /// 双指针
        /// 先将二叉搜索树展平为数组，然后双指针解决。
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool FindTarget(TreeNode root, int k)
        {
            if (root == null) return false;

            List<int> list = new List<int>();
            dfs(root, list);
            int left = 0, right = list.Count - 1;
            while (left < right)
            {
                switch (list[left] + list[right] - k)
                {
                    case > 0: right--; break;
                    case < 0: left++; break;
                    default: return true;
                }
            }

            return false;
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
