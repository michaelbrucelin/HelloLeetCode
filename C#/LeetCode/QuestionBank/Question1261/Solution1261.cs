using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1261
{
    public class Solution1261
    {
    }

    /// <summary>
    /// DFS
    /// DFS先序遍历还原二叉树
    /// </summary>
    public class FindElements : Interface1261
    {
        public FindElements(TreeNode root)
        {
            set = new HashSet<int>();
            if (root == null) return;
            root.val = 0;
            dfs(root);
            set.Add(0);
        }

        private HashSet<int> set;

        public bool Find(int target)
        {
            return set.Contains(target);
        }

        private void dfs(TreeNode root)
        {
            if (root.left != null)
            {
                root.left.val = (root.val << 1) + 1;
                dfs(root.left);
                set.Add(root.left.val);
            }
            if (root.right != null)
            {
                root.right.val = (root.val << 1) + 2;
                dfs(root.right);
                set.Add(root.right.val);
            }
        }
    }
}
