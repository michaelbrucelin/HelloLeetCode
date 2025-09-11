using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0230
{
    public class Solution0230 : Interface0230
    {
        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallest(TreeNode root, int k)
        {
            int _k = 0;
            return (dfs(root)).Value;  // 题目限定，结果一定不为null

            int? dfs(TreeNode node)
            {
                if (node == null) return null;
                int? result;
                if ((result = dfs(node.left)) != null) return result;
                if (++_k == k) return node.val;
                return dfs(node.right);
            }
        }
    }
}
