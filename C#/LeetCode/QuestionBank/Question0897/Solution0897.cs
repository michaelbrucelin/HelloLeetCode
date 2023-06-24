using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0897
{
    public class Solution0897 : Interface0897
    {
        /// <summary>
        /// 递归
        /// 1. 先中序遍历将结点放入一个List中
        /// 2. 遍历List组织为一颗新树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode IncreasingBST(TreeNode root)
        {
            List<TreeNode> list = new List<TreeNode>();
            rec(root, list);
            for (int i = 0; i < list.Count - 1; i++)
            {
                list[i].left = null; list[i].right = list[i + 1];
            }
            list[^1].left = list[^1].right = null;

            return list[0];
        }

        private void rec(TreeNode root, List<TreeNode> list)
        {
            if (root == null) return;
            rec(root.left, list);
            list.Add(root);
            rec(root.right, list);
        }
    }
}
