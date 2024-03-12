using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1261
{
    public class Solution1261_3
    {
    }

    /// <summary>
    /// 找规律
    /// 逻辑同Solution1261，但是Find()的实现不依赖于Hash表，而是找规律
    /// 如果存在target，必然存在(target-1)/2，如果target是奇数，则是父节点的左孩子，偶数，父节点的右孩子
    /// 
    /// 官解的第二种解法本质上就是这种解法，但是更巧妙，利用了二进制，将Find()的递归变成了迭代
    /// </summary>
    public class FindElements_3 : Interface1261
    {
        public FindElements_3(TreeNode root)
        {
            if ((this.root = root) == null) return;
            root.val = 0;
            dfs(root);
        }

        private TreeNode root;

        public bool Find(int target)
        {
            return _Find(target) != null;
        }

        private TreeNode _Find(int target)
        {
            if (target == 0) return root;
            TreeNode parent = _Find((target - 1) >> 1);
            if (parent == null) return null;
            return (target & 1) == 1 ? parent.left : parent.right;
        }

        private void dfs(TreeNode root)
        {
            if (root.left != null)
            {
                root.left.val = (root.val << 1) + 1;
                dfs(root.left);
            }
            if (root.right != null)
            {
                root.right.val = (root.val << 1) + 2;
                dfs(root.right);
            }
        }
    }
}
