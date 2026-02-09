using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0124
{
    public class Solution0124 : Interface0124
    {
        /// <summary>
        /// 递归
        /// 纸上画一下就好了，前序可以找到根，中序可以根据前序找到的根，做出左子树和右子树的范围
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode DeduceTree(int[] preorder, int[] inorder)
        {
            int n = inorder.Length;
            if (n == 0) return null;
            if (n == 1) return new TreeNode(inorder[0]);

            return rec(0, n - 1, 0, n - 1);

            TreeNode rec(int pre_left, int pre_right, int in_left, int in_right)
            {
                if (in_left > in_right) return null;
                if (in_left == in_right) return new TreeNode(inorder[in_left]);

                TreeNode root = new TreeNode(preorder[pre_left]);
                int idx = in_left - 1, rval = preorder[pre_left];
                while (inorder[++idx] != rval) ;
                root.left = rec(pre_left + 1, pre_left + idx - in_left, in_left, idx - 1);
                root.right = rec(pre_left + idx - in_left + 1, pre_right, idx + 1, in_right);

                return root;
            }
        }
    }
}
