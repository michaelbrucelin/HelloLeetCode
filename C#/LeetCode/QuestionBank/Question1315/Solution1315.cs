using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1315
{
    public class Solution1315 : Interface1315
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumEvenGrandparent(TreeNode root)
        {
            return dfs(root, false, false);

            static int dfs(TreeNode node, bool parent, bool grand)
            {
                if (node == null) return 0;
                int result = 0;
                if (grand) result = node.val;
                result += dfs(node.left, (node.val & 1) == 0, parent);
                result += dfs(node.right, (node.val & 1) == 0, parent);

                return result;
            }
        }
    }
}
