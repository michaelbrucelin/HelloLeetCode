using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0701
{
    public class Solution0701 : Interface0701
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);

            TreeNode ptr = root;
            while (ptr.val != val)
            {
                if (val < ptr.val)
                {
                    if (ptr.left == null) ptr.left = new TreeNode(val);
                    ptr = ptr.left;
                }
                else  // if (val > ptr.val)  // 题目限定值一定不等
                {
                    if (ptr.right == null) ptr.right = new TreeNode(val);
                    ptr = ptr.right;
                }
            }

            return root;
        }
    }
}
