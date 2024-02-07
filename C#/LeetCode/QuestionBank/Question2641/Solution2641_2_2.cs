using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2641
{
    public class Solution2641_2_2 : Interface2641
    {
        /// <summary>
        /// DFS
        /// 逻辑同Solution2641_2，只是将递归改为了显式的栈，使用迭代实现
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ReplaceValueInTree(TreeNode root)
        {
            Dictionary<TreeNode, (int level, int sum)> map = new Dictionary<TreeNode, (int level, int sum)>();
            List<int> level_sum = new List<int>();
            TreeNode dummy = new TreeNode(0) { left = root };
            dfs_process(dummy, 0, map, level_sum);
            dfs(root, map, level_sum);

            return root;
        }

        private void dfs(TreeNode node, Dictionary<TreeNode, (int level, int sum)> map, List<int> level_sum)
        {
            if (node == null) return;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode ptr = node;
            while (ptr != null || stack.Count > 0)
            {
                while (ptr != null)
                {
                    ptr.val = level_sum[map[ptr].level] - map[ptr].sum;
                    stack.Push(ptr);
                    ptr = ptr.left;
                }
                ptr = stack.Pop().right;
            }
        }

        private void dfs_process(TreeNode node, int level, Dictionary<TreeNode, (int level, int sum)> map, List<int> level_sum)
        {
            Stack<(TreeNode node, int level)> stack = new Stack<(TreeNode node, int level)>();
            (TreeNode node, int level) ptr = (node, 0);
            while (ptr.node != null || stack.Count > 0)
            {
                while (ptr.node != null)
                {
                    if (level_sum.Count - 1 < ptr.level) level_sum.Add(0); level_sum[ptr.level] += ptr.node.val;
                    if (ptr.node.left != null && ptr.node.right != null)
                    {
                        map.Add(ptr.node.left, (ptr.level + 1, ptr.node.left.val + ptr.node.right.val));
                        map.Add(ptr.node.right, (ptr.level + 1, ptr.node.left.val + ptr.node.right.val));
                    }
                    else if (ptr.node.left != null)
                    {
                        map.Add(ptr.node.left, (ptr.level + 1, ptr.node.left.val));
                    }
                    else if (ptr.node.right != null)
                    {
                        map.Add(ptr.node.right, (ptr.level + 1, ptr.node.right.val));
                    }

                    stack.Push(ptr);
                    ptr = (ptr.node.left, ptr.level + 1);
                }
                ptr = stack.Pop();
                ptr = (ptr.node.right, ptr.level + 1);
            }
        }
    }
}
