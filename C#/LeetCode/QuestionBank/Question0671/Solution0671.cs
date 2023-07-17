using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0671
{
    public class Solution0671 : Interface0671
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindSecondMinimumValue(TreeNode root)
        {
            if (root.left == null) return -1;    // 题目限定必然root.right == null
            int rl = rec(root.left, root.val);
            int rr = rec(root.right, root.val);

            return rl != -1 && rr != -1 ? Math.Min(rl, rr) : Math.Max(rl, rr);
        }

        private int rec(TreeNode node, int min)
        {
            if (node == null) return -1;
            if (node.val > min) return node.val;
            int rl = rec(node.left, min);
            int rr = rec(node.right, min);

            return rl != -1 && rr != -1 ? Math.Min(rl, rr) : Math.Max(rl, rr);
        }
    }
}
