using LeetCode.QuestionBank.Question1000;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0563
{
    public class Solution0563 : Interface0563
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindTilt(TreeNode root)
        {
            if (root == null) return 0;
            return rec(root).tilt;
        }

        private (int tilt, int sum) rec(TreeNode node)
        {
            if (node == null) return (0, 0);

            var tl = rec(node.left); var tr = rec(node.right);
            return (Math.Abs(tl.sum - tr.sum) + tl.tilt + tr.tilt, node.val + tl.sum + tr.sum);
        }
    }
}
