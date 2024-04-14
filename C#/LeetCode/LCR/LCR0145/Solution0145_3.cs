using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0145
{
    public class Solution0145_3 : Interface0145
    {
        /// <summary>
        /// 迭代
        /// 逻辑同Solution0145_2，只是将递归1:1翻译为了迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool CheckSymmetricTree(TreeNode root)
        {
            if (root == null) return true;
            Stack<(TreeNode lt, TreeNode rt)> stack = new Stack<(TreeNode lt, TreeNode rt)>();
            stack.Push((root.left, root.right));
            (TreeNode lt, TreeNode rt) item;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                if (item.lt == null && item.rt == null) continue;
                if (item.lt == null || item.rt == null || item.lt.val != item.rt.val) return false;
                stack.Push((item.lt.left, item.rt.right));
                stack.Push((item.lt.right, item.rt.left));
            }

            return true;
        }
    }
}
