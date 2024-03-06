using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0404
{
    public class Solution0404 : Interface0404
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(TreeNode root)
        {
            return rec(root).IsBalance;
        }

        private (bool IsBalance, int Height) rec(TreeNode root)
        {
            if (root == null) return (true, 0);

            var l = rec(root.left);
            var r = rec(root.right);

            return (l.IsBalance && r.IsBalance && Math.Abs(l.Height - r.Height) <= 1, Math.Max(l.Height, r.Height) + 1);
        }
    }
}
