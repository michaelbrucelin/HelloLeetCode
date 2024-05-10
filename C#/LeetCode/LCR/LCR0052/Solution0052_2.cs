using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0052
{
    public class Solution0052_2 : Interface0052
    {
        /// <summary>
        /// 逻辑同Solution0052，只是将递归1:1翻译为迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode IncreasingBST(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null)) return root;

            List<TreeNode> inorder = new List<TreeNode>();
            Stack<(TreeNode node, bool todo)> stack = new Stack<(TreeNode node, bool todo)>();
            stack.Push((root, false));
            (TreeNode node, bool todo) ptr;
            while (stack.Count > 0)
            {
                if ((ptr = stack.Pop()).node != null)
                {
                    if (ptr.todo)
                    {
                        inorder.Add(ptr.node);
                    }
                    else
                    {
                        stack.Push((ptr.node.right, false));
                        stack.Push((ptr.node, true));
                        stack.Push((ptr.node.left, false));
                    }
                }
            }
            inorder.Add(null);

            int cnt = inorder.Count;
            for (int i = 0; i < cnt - 1; i++)
            {
                inorder[i].left = null; inorder[i].right = inorder[i + 1];
            }

            return inorder[0];
        }
    }
}
