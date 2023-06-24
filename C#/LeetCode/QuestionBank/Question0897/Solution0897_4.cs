using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0897
{
    public class Solution0897_4 : Interface0897
    {
        /// <summary>
        /// 与Solution0897逻辑一样，只是将递归改为染色法迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode IncreasingBST(TreeNode root)
        {
            List<TreeNode> list = new List<TreeNode>();
            Stack<(bool tag, TreeNode node)> stack = new Stack<(bool, TreeNode)>();  // true:白色, false:灰色
            stack.Push((true, root));
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                if (item.node == null) continue;
                if (item.tag)
                {
                    stack.Push((true, item.node.right));
                    stack.Push((false, item.node));
                    stack.Push((true, item.node.left));
                }
                else
                    list.Add(item.node);
            }

            for (int i = 0; i < list.Count - 1; i++)
            {
                list[i].left = null; list[i].right = list[i + 1];
            }
            list[^1].left = list[^1].right = null;

            return list[0];
        }
    }
}
