using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0222
{
    public class Solution0222 : Interface0222
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int CountNodes(TreeNode root)
        {
            if (root == null) return 0;

            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }
    }
}
