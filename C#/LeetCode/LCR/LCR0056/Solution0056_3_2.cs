using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0056
{
    public class Solution0056_3_2 : Interface0056
    {
        /// <summary>
        /// 同Solution0056_3
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool FindTarget(TreeNode root, int k)
        {
            if (root == null) return false;

            return FindTarget(root, k, new HashSet<int>());
        }

        private bool FindTarget(TreeNode root, int k, HashSet<int> set)
        {
            if (root == null) return false;
            if (set.Contains(k - root.val)) return true;
            set.Add(root.val);

            return FindTarget(root.left, k, set) || FindTarget(root.right, k, set);
        }
    }
}
