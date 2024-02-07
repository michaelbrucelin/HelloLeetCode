using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2641
{
    public class Solution2641_2 : Interface2641
    {
        /// <summary>
        /// DFS
        /// 逻辑没问题，但是提交栈溢出了，怀疑是递归的层数太多导致的
        /// 
        /// 就是递归层数太多，栈溢出了，改为显示栈迭代（Solution2641_2_2）提交就通过了
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
            node.val = level_sum[map[node].level] - map[node].sum;
            dfs(node.left, map, level_sum);
            dfs(node.right, map, level_sum);
        }

        private void dfs_process(TreeNode node, int level, Dictionary<TreeNode, (int level, int sum)> map, List<int> level_sum)
        {
            if (level_sum.Count - 1 < level) level_sum.Add(0); level_sum[level] += node.val;
            if (node.left != null && node.right != null)
            {
                map.Add(node.left, (level + 1, node.left.val + node.right.val));
                dfs_process(node.left, level + 1, map, level_sum);
                map.Add(node.right, (level + 1, node.left.val + node.right.val));
                dfs_process(node.right, level + 1, map, level_sum);
            }
            else if (node.left != null)
            {
                map.Add(node.left, (level + 1, node.left.val));
                dfs_process(node.left, level + 1, map, level_sum);
            }
            else if (node.right != null)
            {
                map.Add(node.right, (level + 1, node.right.val));
                dfs_process(node.right, level + 1, map, level_sum);
            }
        }
    }
}
