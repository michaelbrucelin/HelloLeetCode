using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0150
{
    public class Solution0150_3 : Interface0150
    {
        /// <summary>
        /// 迭代
        /// 逻辑与Solution0150_2一样，只是将递归1:1翻译为迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> DecorateRecord(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            Stack<(TreeNode node, int level)> stack = new Stack<(TreeNode node, int level)>();
            stack.Push((root, 0));
            (TreeNode node, int level) item;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                if (result.Count == item.level) result.Add(new List<int>());
                result[item.level].Add(item.node.val);
                if (item.node.right != null) stack.Push((item.node.right, item.level + 1));
                if (item.node.left != null) stack.Push((item.node.left, item.level + 1));
            }

            return result;
        }
    }
}
