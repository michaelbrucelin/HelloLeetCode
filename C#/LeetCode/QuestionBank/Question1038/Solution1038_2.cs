using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1038
{
    public class Solution1038_2 : Interface1038
    {
        /// <summary>
        /// 反序中序遍历
        /// 逻辑同Solution1038，只是将局部变量撤销了，改为变量传递
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode BstToGst(TreeNode root)
        {
            TreeNode last = null;
            return rec(root, ref last);
        }

        private TreeNode rec(TreeNode root, ref TreeNode last)
        {
            if (root == null) return null;

            rec(root.right, ref last);
            if (last != null) root.val += last.val;
            last = root;
            rec(root.left, ref last);

            return root;
        }
    }
}
