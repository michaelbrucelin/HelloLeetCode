using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0098
{
    public class Solution0098_2 : Interface0098
    {
        /// <summary>
        /// 逻辑同Solution0098，将List<int>改为int
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root)
        {
            long last = long.MinValue;
            return dfs(root);

            bool dfs(TreeNode node)
            {
                if (node == null) return true;
                if (!dfs(node.left)) return false;
                if (node.val <= last) return false; else last = node.val;
                return dfs(node.right);
            }
        }
    }
}
