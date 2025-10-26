using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0193
{
    public class Solution0193 : Interface0193
    {
        /// <summary>
        /// 递归
        /// 到主库的0235题去提交验证
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == p || root == q) return root;
            if (1L * (root.val - p.val) * (root.val - q.val) < 0) return root;

            return LowestCommonAncestor(root.val > p.val ? root.left : root.right, p, q);
        }
    }
}
