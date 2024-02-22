using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0889
{
    public class Solution0889_2 : Interface0889
    {
        /// <summary>
        /// 迭代
        /// 逻辑与Solution0889一样，只是将递归改为了显示的栈迭代，写着玩的
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="postorder"></param>
        /// <returns></returns>
        public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
        {
            if (preorder == null || preorder.Length == 0) return null;
            if (preorder.Length == 1) return new TreeNode(preorder[0]);

            Dictionary<int, int> postmap = new Dictionary<int, int>();
            for (int i = 0; i < postorder.Length; i++) postmap.Add(postorder[i], i);  // 题目限定postorder中的值互不相同

            TreeNode dummy = new TreeNode(int.MinValue);
            Stack<(TreeNode root, bool isLeft, int preleft, int preright, int postleft, int postright)> stack
                = new Stack<(TreeNode root, bool isLeft, int preleft, int preright, int postleft, int postright)>();
            stack.Push((dummy, true, 0, preorder.Length - 1, 0, postorder.Length - 1));
            (TreeNode root, bool isLeft, int preleft, int preright, int postleft, int postright) item;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                if (item.preleft > item.preright) continue;
                TreeNode root = new TreeNode(preorder[item.preleft]);
                if (item.isLeft) item.root.left = root; else item.root.right = root;
                if (item.preleft == item.preright) continue;

                int postid = postmap[preorder[item.preleft + 1]];
                if (postid == item.postright - 1)
                {
                    stack.Push((root, true, item.preleft + 1, item.preright, item.postleft, item.postright - 1));
                }
                else
                {
                    stack.Push((root, true, item.preleft + 1, item.preleft + (postid - item.postleft + 1), item.postleft, postid));
                    stack.Push((root, false, item.preleft + (postid - item.postleft + 1) + 1, item.preright, postid + 1, item.postright - 1));
                }
            }

            return dummy.left;
        }
    }
}
