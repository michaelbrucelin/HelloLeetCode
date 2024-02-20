using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0105
{
    public class Solution0105_2 : Interface0105
    {
        /// <summary>
        /// 递归
        /// 逻辑同Solution0105，但是inorder做了哈希化，方便在inorder中查找子树的根节点
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            Dictionary<int, int> inmap = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++) inmap.Add(inorder[i], i);

            return rec(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1, inmap);
        }

        private TreeNode rec(int[] preorder, int preleft, int preright, int[] inorder, int inleft, int inright, Dictionary<int, int> inmap)
        {
            if (preleft > preright) return null;

            TreeNode root = new TreeNode(preorder[preleft]);
            if (preleft == preright) return root;

            int inid = inmap[preorder[preleft]];
            if (inid == inleft)
            {
                root.right = rec(preorder, preleft + 1, preright, inorder, inid + 1, inright, inmap);
            }
            else if (inid == inright)
            {
                root.left = rec(preorder, preleft + 1, preright, inorder, inleft, inid - 1, inmap);
            }
            else
            {
                root.left = rec(preorder, preleft + 1, preleft + inid - inleft, inorder, inleft, inid - 1, inmap);
                root.right = rec(preorder, preleft + inid - inleft + 1, preright, inorder, inid + 1, inright, inmap);
            }

            return root;
        }
    }
}
