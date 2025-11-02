using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0538
{
    public class Solution0538_2 : Interface0538
    {
        /// <summary>
        /// 镜像中序遍历
        /// 右 - 根 - 左 遍历
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
                node.val += sum;
                sum = node.val;
                dfs(node.left);
            }
        }
    }
}
