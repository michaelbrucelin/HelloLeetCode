using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0175
{
    public class Solution0175_2 : Interface0175
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int CalculateDepth(TreeNode root)
        {
            if (root == null) return 0;

            return Math.Max(CalculateDepth(root.left), CalculateDepth(root.right)) + 1;
        }
    }
}
