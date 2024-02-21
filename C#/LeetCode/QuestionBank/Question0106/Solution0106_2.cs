using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0106
{
    public class Solution0106_2 : Interface0106
    {
        /// <summary>
        /// 迭代
        /// 逻辑同Solution0106，将递归改为了迭代，写着玩的
        /// </summary>
        /// <param name="inorder"></param>
        /// <param name="postorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (postorder == null || postorder.Length == 0) return null;
            if (postorder.Length == 1) return new TreeNode(postorder[0]);

            TreeNode dummy = new TreeNode(int.MinValue);
            Dictionary<int, int> inmap = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++) inmap.Add(inorder[i], i);
            Stack<(TreeNode node, bool isLeft, int postleft, int postright, int inleft, int inright)> stack =
                new Stack<(TreeNode node, bool isLeft, int postleft, int postright, int inleft, int inright)>();
            stack.Push((dummy, true, 0, postorder.Length - 1, 0, inorder.Length - 1));
            (TreeNode node, bool isLeft, int postleft, int postright, int inleft, int inright) item;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                if (item.postleft > item.postright) continue;

                TreeNode root = new TreeNode(postorder[item.postright]);
                if (item.isLeft) item.node.left = root; else item.node.right = root;
                if (item.postleft == item.postright) continue;

                int inid = inmap[postorder[item.postright]];
                if (inid == item.inleft)
                {
                    stack.Push((root, false, item.postleft, item.postright - 1, inid + 1, item.inright));
                }
                else if (inid == item.inright)
                {
                    stack.Push((root, true, item.postleft, item.postright - 1, item.inleft, inid - 1));
                }
                else
                {
                    stack.Push((root, true, item.postleft, item.postleft + (inid - item.inleft) - 1, item.inleft, inid - 1));
                    stack.Push((root, false, item.postleft + (inid - item.inleft), item.postright - 1, inid + 1, item.inright));
                }
            }

            return dummy.left;
        }
    }
}
