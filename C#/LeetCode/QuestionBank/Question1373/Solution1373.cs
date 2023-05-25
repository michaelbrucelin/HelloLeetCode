using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1373
{
    public class Solution1373 : Interface1373
    {
        /// <summary>
        /// 递归
        /// 递归函数的结果为(bool is, int min, int max, int sum, int sub)
        ///     is表示子树是否是二叉搜索树，min与max分别表示二叉搜索树的最小值及最大值，sum是子树的和，sub表示子树中最大的二叉搜索树的和
        /// 1. 如果node为null，结果为(true, 0, 0, 0, 0)，（空树）
        /// 2. 如果node为叶子节点，结果为(true, val, val, val, MAX(val, 0))
        /// 3. 如果node有后代节点
        ///     递归计算左孩子的结果：r_left
        ///     递归计算右孩子的结果：r_right
        ///     如果r_left.is && r_left.max < node && r_right.is && r_right.min > node，
        ///         node的结果是：(true, r_left.min, r_right.max, node + r_left.sum + r_right.sum, MAX(r_left.sub, r_right.sub, node + r_left.sum + r_right.sum))
        ///     否则，
        ///         node的结果是：(false, 0, 0, 0, MAX(r_left.sub, r_right.sub))
        /// 
        /// 直觉当二叉搜索树的和为负值时可以剪枝，这里没有证明和优化
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxSumBST(TreeNode root)
        {
            if (root == null) return 0;
            return rec(root).sub;
        }

        private (bool _is, int min, int max, int sum, int sub) rec(TreeNode node)
        {
            if (node == null) return (true, 0, 0, 0, 0);
            if (node.left == null && node.right == null) return (true, node.val, node.val, node.val, Math.Max(node.val, 0));
            if (node.left != null && node.right != null)
            {
                var tl = rec(node.left); var tr = rec(node.right);
                if (tl._is && tl.max < node.val && tr._is && tr.min > node.val)
                    return (true, tl.min, tr.max, node.val + tl.sum + tr.sum, Math.Max(node.val + tl.sum + tr.sum, Math.Max(tl.sub, tr.sub)));
                else
                    return (false, 0, 0, 0, Math.Max(tl.sub, tr.sub));
            }
            if (node.left != null)
            {
                var tl = rec(node.left);
                if (tl._is && tl.max < node.val)
                    return (true, tl.min, node.val, node.val + tl.sum, Math.Max(node.val + tl.sum, tl.sub));
                else
                    return (false, 0, 0, 0, tl.sub);
            }
            if (node.right != null)
            {
                var tr = rec(node.right);
                if (tr._is && tr.min > node.val)
                    return (true, node.val, tr.max, node.val + tr.sum, Math.Max(node.val + tr.sum, tr.sub));
                else
                    return (false, 0, 0, 0, tr.sub);
            }

            throw new Exception("logic error.");
        }
    }
}
