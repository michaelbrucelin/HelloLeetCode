using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1261
{
    public class Solution1261_2
    {
    }

    /// <summary>
    /// BFS
    /// BFS先序遍历还原二叉树
    /// </summary>
    public class FindElements_2 : Interface1261
    {
        public FindElements_2(TreeNode root)
        {
            set = new HashSet<int>();
            if (root == null) return;
            root.val = 0;
            bfs(root);
        }

        private HashSet<int> set;

        public bool Find(int target)
        {
            return set.Contains(target);
        }

        private void bfs(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                set.Add(item.val);
                if (item.left != null)
                {
                    item.left.val = (item.val << 1) + 1;
                    queue.Enqueue(item.left);
                }
                if (item.right != null)
                {
                    item.right.val = (item.val << 1) + 2;
                    queue.Enqueue(item.right);
                }
            }
        }
    }
}
