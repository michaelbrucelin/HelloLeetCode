using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0144
{
    public class Solution0144_2 : Interface0144
    {
        /// <summary>
        /// 迭代
        /// 逻辑同Solution0144，只是将递归1:1翻译为迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode MirrorTree(TreeNode root)
        {
            if (root == null) return null;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            TreeNode item;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                if (item == null) continue;
                TreeNode lchild = item.left;
                item.left = item.right; stack.Push(item.right);
                item.right = lchild; stack.Push(lchild);
            }

            return root;
        }
    }
}
