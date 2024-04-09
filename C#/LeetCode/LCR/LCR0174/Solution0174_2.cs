using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0174
{
    public class Solution0174_2 : Interface0174
    {
        /// <summary>
        /// 迭代
        /// 逻辑同Solution0174，只是将递归1:1翻译为迭代
        /// </summary>
        /// <param name="root"></param>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public int FindTargetNode(TreeNode root, int cnt)
        {
            int result = -1, order = 1;
            Stack<(TreeNode node, bool todo)> stack = new Stack<(TreeNode node, bool todo)>();
            stack.Push((root, false));
            (TreeNode node, bool todo) item;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                if (item.todo)
                {
                    if (order++ == cnt) { result = item.node.val; break; }
                }
                else
                {
                    if (item.node.left != null) stack.Push((item.node.left, false));
                    stack.Push((item.node, true));
                    if (item.node.right != null) stack.Push((item.node.right, false));
                }
            }

            return result;
        }
    }
}
