using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0513
{
    public class Solution0513_2 : Interface0513
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindBottomLeftValue(TreeNode root)
        {
            int result = root.val, depth = 1;
            dfs(root, 1);
            return result;

            void dfs(TreeNode node, int _depth)
            {
                if (node.left == null && node.right == null)
                {
                    if (_depth > depth)
                    {
                        result = node.val;
                        depth = _depth;
                    }
                }
                else
                {
                    if (node.left != null) dfs(node.left, _depth + 1);
                    if (node.right != null) dfs(node.right, _depth + 1);
                }
            }
        }
    }
}
