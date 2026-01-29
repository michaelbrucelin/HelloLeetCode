using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0054
{
    public class Solution0054_2 : Interface0054
    {
        /// <summary>
        /// 反向中序遍历
        /// 右 -> 根 -> 左 遍历，本质上与Solution0054一样
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ConvertBST(TreeNode root)
        {
            int sum = 0;
            dfs(root);
            return root;

            void dfs(TreeNode node)
            {
                if (node == null) return;

                dfs(node.right);
                sum += node.val; node.val = sum;
                dfs(node.left);
            }
        }
    }
}
