using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1712
{
    public class Solution1712_2 : Interface1712
    {
        /// <summary>
        /// 迭代
        /// 逻辑同Solution1712，将递归1:1翻译为迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ConvertBiNode(TreeNode root)
        {
            List<TreeNode> list = new List<TreeNode>();
            Stack<(TreeNode node, bool flag)> stack = new Stack<(TreeNode node, bool flag)>();
            stack.Push((root, false));
            (TreeNode node, bool flag) ptr;
            while (stack.Count > 0)
            {
                ptr = stack.Pop();
                if (ptr.node == null) continue;
                if (ptr.flag)
                {
                    list.Add(ptr.node);
                }
                else
                {
                    stack.Push((ptr.node.right, false));
                    stack.Push((ptr.node, true));
                    stack.Push((ptr.node.left, false));
                }
            }

            list.Add(null);
            for (int i = 0; i < list.Count - 1; i++)
            {
                list[i].left = null; list[i].right = list[i + 1];
            }

            return list[0];
        }
    }
}
