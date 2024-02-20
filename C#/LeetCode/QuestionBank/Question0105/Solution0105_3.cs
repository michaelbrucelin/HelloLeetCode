using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0105
{
    public class Solution0105_3 : Interface0105
    {
        /// <summary>
        /// 迭代
        /// 逻辑同Solution0105_2，将递归改为了迭代，写着玩的
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || preorder.Length == 0) return null;
            if (preorder.Length == 1) return new TreeNode(preorder[0]);

            TreeNode dummy = new TreeNode(int.MinValue);
            Dictionary<int, int> inmap = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++) inmap.Add(inorder[i], i);
            Stack<(TreeNode node, bool isLeft, int preleft, int preright, int inleft, int inright)> stack =
                new Stack<(TreeNode node, bool isLeft, int preleft, int preright, int inleft, int inright)>();
            stack.Push((dummy, true, 0, preorder.Length - 1, 0, inorder.Length - 1));
            (TreeNode node, bool isLeft, int preleft, int preright, int inleft, int inright) item;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                if (item.preleft > item.preright) continue;

                TreeNode root = new TreeNode(preorder[item.preleft]);
                if (item.isLeft) item.node.left = root; else item.node.right = root;
                if (item.preleft == item.preright) continue;

                int inid = inmap[preorder[item.preleft]];
                if (inid == item.inleft)
                {
                    stack.Push((root, false, item.preleft + 1, item.preright, inid + 1, item.inright));
                }
                else if (inid == item.inright)
                {
                    stack.Push((root, true, item.preleft + 1, item.preright, item.inleft, inid - 1));
                }
                else
                {
                    stack.Push((root, true, item.preleft + 1, item.preleft + inid - item.inleft, item.inleft, inid - 1));
                    stack.Push((root, false, item.preleft + inid - item.inleft + 1, item.preright, inid + 1, item.inright));
                }
            }

            return dummy.left;
        }
    }
}
