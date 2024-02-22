using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0889
{
    public class Solution0889 : Interface0889
    {
        /// <summary>
        /// 递归
        /// 前序遍历 + 后序遍历 的结果不一定有唯一解
        ///     典型的 preorder = [1, 2], postorder = [2, 1]
        ///     2 既可以是 1 的左孩子，也可以是 1 的右孩子
        /// 这里优先考虑左孩子
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

            return rec(preorder, 0, preorder.Length - 1, postorder, 0, postorder.Length - 1, postmap);
        }

        private TreeNode rec(int[] preorder, int preleft, int preright, int[] postorder, int postleft, int postright, Dictionary<int, int> postmap)
        {
            if (preleft > preright) return null;
            TreeNode root = new TreeNode(preorder[preleft]);
            if (preleft == preright) return root;

            int postid = postmap[preorder[preleft + 1]];
            if (postid == postright - 1)
            {
                root.left = rec(preorder, preleft + 1, preright, postorder, postleft, postright - 1, postmap);
            }
            else
            {
                root.left = rec(preorder, preleft + 1, preleft + (postid - postleft + 1), postorder, postleft, postid, postmap);
                root.right = rec(preorder, preleft + (postid - postleft + 1) + 1, preright, postorder, postid + 1, postright - 1, postmap);
            }

            return root;
        }
    }
}
