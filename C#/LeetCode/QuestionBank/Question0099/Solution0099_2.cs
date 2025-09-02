using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0099
{
    public class Solution0099_2 : Interface0099
    {
        /// <summary>
        /// 进阶，将空间复杂度降为O(1)
        /// 逻辑与Solution0099完全一样，只是取消了List<TreeNode>
        /// 中序遍历一次找出两个需要交换的TreeNode
        /// </summary>
        /// <param name="root"></param>
        public void RecoverTree(TreeNode root)
        {
            List<TreeNode> list = new List<TreeNode>();
            TreeNode last = new TreeNode(int.MinValue);
            dfs(root);
            int t = list[0].val; list[0].val = list[1].val; list[1].val = t;
            return;

            void dfs(TreeNode node)
            {
                if (node == null) return;
                dfs(node.left);
                if (node.val < last.val)
                {
                    if (list.Count == 0) { list.Add(last); list.Add(node); } else list[1] = node;
                }
                last = node;
                dfs(node.right);
            }
        }
    }
}
