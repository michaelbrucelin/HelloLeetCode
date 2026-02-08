using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0110
{
    public class Solution0110_2 : Interface0110
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(TreeNode root)
        {
            return rec(root).Item1;

            static (bool, int) rec(TreeNode node)
            {
                if (node == null) return (true, 0);

                (bool, int) linfo = rec(node.left);
                if (!linfo.Item1) return (false, -1);
                (bool, int) rinfo = rec(node.right);
                if (!rinfo.Item1) return (false, -1);

                return (Math.Abs(linfo.Item2 - rinfo.Item2) < 2, Math.Max(linfo.Item2, rinfo.Item2) + 1);
            }
        }
    }
}
