using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0106
{
    public class Solution0106 : Interface0106
    {
        /// <summary>
        /// 递归
        /// 思路同Solution0105
        /// </summary>
        /// <param name="inorder"></param>
        /// <param name="postorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            Dictionary<int, int> inmap = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++) inmap.Add(inorder[i], i);

            return rec(postorder, 0, postorder.Length - 1, inorder, 0, inorder.Length - 1, inmap);
        }

        private TreeNode rec(int[] postorder, int postleft, int postright, int[] inorder, int inleft, int inright, Dictionary<int, int> inmap)
        {
            if (postleft > postright) return null;

            TreeNode root = new TreeNode(postorder[postright]);
            if (postleft == postright) return root;

            int inid = inmap[postorder[postright]];
            if (inid == inleft)
            {
                root.right = rec(postorder, postleft, postright - 1, inorder, inid + 1, inright, inmap);
            }
            else if (inid == inright)
            {
                root.left = rec(postorder, postleft, postright - 1, inorder, inleft, inid - 1, inmap);
            }
            else
            {
                root.left = rec(postorder, postleft, postleft + (inid - inleft) - 1, inorder, inleft, inid - 1, inmap);
                root.right = rec(postorder, postleft + (inid - inleft), postright - 1, inorder, inid + 1, inright, inmap);
            }

            return root;
        }
    }
}
