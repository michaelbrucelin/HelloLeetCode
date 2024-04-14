using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0144
{
    public class Solution0144 : Interface0144
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode MirrorTree(TreeNode root)
        {
            if (root == null) return null;

            TreeNode lchild = root.left;
            root.left = MirrorTree(root.right);
            root.right = MirrorTree(lchild);

            return root;
        }
    }
}
