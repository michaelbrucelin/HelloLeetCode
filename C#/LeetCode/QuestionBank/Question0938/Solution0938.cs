using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0938
{
    public class Solution0938 : Interface0938
    {
        /// <summary>
        /// 中序遍历 dfs 无返回值
        /// 1. 从根节点向下找到第一个在[low, high]之间的节点
        /// 2. 以这个节点为根节点中序遍历即可
        /// </summary>
        /// <param name="root"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            int result = 0;
            dfs(root, low, high, ref result);

            return result;
        }

        private void dfs(TreeNode node, int low, int high, ref int result)
        {
            if (node == null) return;
            if (node.val < low)
                dfs(node.right, low, high, ref result);
            else if (node.val > high)
                dfs(node.left, low, high, ref result);
            else  // [low, high]
            {
                dfs(node.left, low, high, ref result);
                result += node.val;
                dfs(node.right, low, high, ref result);
            }
        }
    }
}
