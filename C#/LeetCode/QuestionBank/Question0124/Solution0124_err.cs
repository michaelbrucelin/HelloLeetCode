using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0124
{
    public class Solution0124_err : Interface0124
    {
        /// <summary>
        /// 递归
        /// 递归的结果为(包含根节点的最大值, 不包含根节点的最大值)，然后自底向上构造
        /// 
        /// 题目理解错了，题目要的是最大的“线性”路径，这里求解的是最大的子树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxPathSum(TreeNode root)
        {
            var (r1, r2) = rec(root);
            return Math.Max(r1, r2);

            static (int, int) rec(TreeNode node)
            {
                int r1 = node.val, r2 = int.MinValue;

                int _r1, _r2;
                if (node.left != null)
                {
                    (_r1, _r2) = rec(node.left);
                    if (_r1 > 0) r1 += _r1;
                    r2 = Math.Max(r2, Math.Max(_r1, _r2));
                }
                if (node.right != null)
                {
                    (_r1, _r2) = rec(node.right);
                    if (_r1 > 0) r1 += _r1;
                    r2 = Math.Max(r2, Math.Max(_r1, _r2));
                }

                return (r1, r2);
            }
        }
    }
}
