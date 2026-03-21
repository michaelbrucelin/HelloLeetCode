using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0124
{
    public class Solution0124 : Interface0124
    {
        /// <summary>
        /// 递归
        /// 递归的结果为(子树的最大值, 根节点的最大线性序列（左或右）)，然后自底向上构造
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxPathSum(TreeNode root)
        {
            return rec(root).Item1;

            static (int, int) rec(TreeNode node)
            {
                int r1 = node.val, r2 = node.val;

                int rl1, rl2, rr1, rr2;
                switch ((node.left, node.right))
                {
                    case (null, null): break;
                    case (_, null):
                        (rl1, rl2) = rec(node.left);
                        if (rl2 > 0) { r1 += rl2; r2 += rl2; }
                        r1 = Math.Max(r1, rl1);
                        break;
                    case (null, _):
                        (rr1, rr2) = rec(node.right);
                        if (rr2 > 0) { r1 += rr2; r2 += rr2; }
                        r1 = Math.Max(r1, rr1);
                        break;
                    case (_, _):
                        (rl1, rl2) = rec(node.left);
                        (rr1, rr2) = rec(node.right);
                        if (rl2 > 0) r1 += rl2; if (rr2 > 0) r1 += rr2;
                        r1 = Math.Max(r1, Math.Max(rl1, rr1));
                        r2 = Math.Max(r2, r2 + Math.Max(rl2, rr2));
                        break;
                }

                return (r1, r2);
            }
        }
    }
}
