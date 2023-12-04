using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1038
{
    public class Solution1038 : Interface1038
    {
        private TreeNode last = null;

        /// <summary>
        /// 反序中序遍历
        /// 每个节点的值更新为下面几个值的和
        ///     1. 自身
        ///     2. 右子树的和
        ///     3. 如果自身是父结点的左孩子
        ///         3.1. 父结点
        ///         3.2. 父结点右子树的和
        /// 根据上面的分析，如果采用反序中序遍历（右-根-左），每个节点的值都应该是自身与“上一个”节点的值的和
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode BstToGst(TreeNode root)
        {
            if (root == null) return null;

            BstToGst(root.right);
            if (last != null) root.val += last.val;
            last = root;
            BstToGst(root.left);

            return root;
        }
    }
}
