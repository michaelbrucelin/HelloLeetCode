using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0056
{
    public class Solution0056 : Interface0056
    {
        /// <summary>
        /// 递归 + 二分
        /// 枚举每一个值，二分查找另一个值
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool FindTarget(TreeNode root, int k)
        {
            return FindTarget(root, root, k);
        }

        private bool FindTarget(TreeNode root, TreeNode node, int k)
        {
            if (node == null) return false;
            if ((node.val << 1) != k && _FindTarget(root, k - node.val)) return true;
            if (FindTarget(root, node.left, k)) return true;
            if (FindTarget(root, node.right, k)) return true;

            return false;
        }

        private bool _FindTarget(TreeNode root, int target)
        {
            if (root == null) return false;
            switch (root.val - target)
            {
                case > 0: return _FindTarget(root.left, target);
                case < 0: return _FindTarget(root.right, target);
                default: return true;
            }
        }
    }
}
