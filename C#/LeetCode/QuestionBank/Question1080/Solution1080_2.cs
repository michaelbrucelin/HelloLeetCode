using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1080
{
    public class Solution1080_2 : Interface1080
    {
        /// <summary>
        /// bfs
        /// </summary>
        /// <param name="root"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public TreeNode SufficientSubset(TreeNode root, int limit)
        {
            HashSet<TreeNode> set_no = new HashSet<TreeNode>();
            List<TreeNode> path = new List<TreeNode>() { root };
            Queue<(List<TreeNode> path, int sum)> queue = new Queue<(List<TreeNode> path, int sum)>();
            queue.Enqueue((path, root.val));
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    var t = queue.Dequeue();
                    TreeNode node = t.path[^1];
                    if (node.left == null && node.right == null)
                    {
                        if (t.sum >= limit) for (int j = 0; j < t.path.Count; j++) set_no.Add(t.path[j]);
                    }
                    else
                    {
                        if (node.left != null) queue.Enqueue((new List<TreeNode>(t.path) { node.left }, t.sum + node.left.val));
                        if (node.right != null) queue.Enqueue((new List<TreeNode>(t.path) { node.right }, t.sum + node.right.val));
                    }
                }
            }
            if (!set_no.Contains(root)) return null;

            Queue<TreeNode> _queue = new Queue<TreeNode>();
            _queue.Enqueue(root);
            while ((cnt = _queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = _queue.Dequeue();
                    if (node.left != null)
                    {
                        if (set_no.Contains(node.left)) _queue.Enqueue(node.left); else node.left = null;
                    }
                    if (node.right != null)
                    {
                        if (set_no.Contains(node.right)) _queue.Enqueue(node.right); else node.right = null;
                    }
                }
            }

            return root;
        }
    }
}
