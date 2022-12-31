using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0100
{
    public class Solution0100_2 : Interface0100
    {
        /// <summary>
        /// 同时遍历两棵树
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            return dfs(p, q);
        }

        private bool dfs(TreeNode node1, TreeNode node2)
        {
            if (node1 == null && node2 == null) return true;
            if (node1 == null || node2 == null) return false;
            if (node1.val != node2.val) return false;
            if (dfs(node1.left, node2.left))
                return dfs(node1.right, node2.right);
            else
                return false;
        }
    }
}
