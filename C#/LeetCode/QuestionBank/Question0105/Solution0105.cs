using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0105
{
    public class Solution0105 : Interface0105
    {
        /// <summary>
        /// 递归
        /// 1. 前序遍历的第1项是根，紧接着一个连续的区间是左子树，剩下的连续区间是右子树
        /// 2. 中序遍历根左边的项是左子树，根右边的项是右子树
        /// 
        /// 优化，哈希化preorder与inorder的值对应的id
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return rec(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }

        private TreeNode rec(int[] preorder, int preleft, int preright, int[] inorder, int inleft, int inright)
        {
            if (preleft > preright) return null;

            TreeNode root = new TreeNode(preorder[preleft]);
            if (preleft == preright) return root;

            int inid;
            for (inid = inleft; inid <= inright; inid++) if (inorder[inid] == preorder[preleft]) break;
            if (inid == inleft)
            {
                root.right = rec(preorder, preleft + 1, preright, inorder, inid + 1, inright);
            }
            else if (inid == inright)
            {
                root.left = rec(preorder, preleft + 1, preright, inorder, inleft, inid - 1);
            }
            else
            {
                root.left = rec(preorder, preleft + 1, preleft + inid - inleft, inorder, inleft, inid - 1);
                root.right = rec(preorder, preleft + inid - inleft + 1, preright, inorder, inid + 1, inright);
            }

            return root;
        }
    }
}
