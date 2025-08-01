using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0114
{
    public class Solution0114_2 : Interface0114
    {
        /// <summary>
        /// 原地操作
        /// 1. 从根节点开始遍历
        /// 2. 如果当前节点没有左子节点，指针指向右子节点
        /// 3. 如果当前节点存在左子节点，右子节点移到左子树最右边节点的右子节点，左子节点移到右子节点
        /// 具体逻辑参考官解
        /// </summary>
        /// <param name="root"></param>
        public void Flatten(TreeNode root)
        {
            if (root == null) return;
            if (root.left == null && root.right == null) return;

            TreeNode ptr = root, _ptr;
            while (ptr != null)
            {
                if (ptr.left != null)
                {
                    _ptr = ptr.left;
                    while (_ptr.left != null || _ptr.right != null) _ptr = _ptr.right != null ? _ptr.right : _ptr.left;
                    _ptr.right = ptr.right;
                    ptr.right = ptr.left;
                    ptr.left = null;
                }
                ptr = ptr.right;
            }
        }
    }
}
