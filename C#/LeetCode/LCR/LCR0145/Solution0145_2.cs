using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0145
{
    public class Solution0145_2 : Interface0145
    {
        /// <summary>
        /// 递归
        /// 如果两棵树轴对称，那么
        ///     1. 两棵树的根的值相同
        ///     2. 左树的左子树与右树的右子树轴对称
        ///     3. 左树的右子树与右树的左子树轴对称
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool CheckSymmetricTree(TreeNode root)
        {
            if (root == null) return true;
            return rec(root.left, root.right);
        }

        private bool rec(TreeNode ltree, TreeNode rtree)
        {
            if (ltree == null && rtree == null) return true;
            if (ltree == null || rtree == null || ltree.val != rtree.val) return false;
            return rec(ltree.left, rtree.right) && rec(ltree.right, rtree.left);
        }
    }
}
