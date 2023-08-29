using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0501
{
    public class Solution0501 : Interface0501
    {
        /// <summary>
        /// 遍历，DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] FindMode(TreeNode root)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            dfs(root, freq);

            int max = 0;
            foreach (int cnt in freq.Values) max = Math.Max(max, cnt);
            List<int> result = new List<int>();
            foreach (var kv in freq) if (kv.Value == max) result.Add(kv.Key);

            return result.ToArray();
        }

        private void dfs(TreeNode node, Dictionary<int, int> freq)
        {
            if (freq.ContainsKey(node.val)) freq[node.val]++; else freq.Add(node.val, 1);
            if (node.left != null) dfs(node.left, freq);
            if (node.right != null) dfs(node.right, freq);
        }

        /// <summary>
        /// 遍历，BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] FindMode2(TreeNode root)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (freq.ContainsKey(node.val)) freq[node.val]++; else freq.Add(node.val, 1);
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            int max = 0;
            foreach (int cnt in freq.Values) max = Math.Max(max, cnt);
            List<int> result = new List<int>();
            foreach (var kv in freq) if (kv.Value == max) result.Add(kv.Key);

            return result.ToArray();
        }
    }
}
