using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0863
{
    public class Solution0863 : Interface0863
    {
        /// <summary>
        /// 回溯 + BFS
        /// 先回溯找到target节点，并记录路径
        ///     从target向下bfs查找k-1层
        ///     以路径中每个节点为根，向另一颗子树上bfs
        /// </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            if (k == 0) return [target.val];

            List<int> result = [];
            List<TreeNode> path = [];
            Queue<TreeNode> queue = new Queue<TreeNode>();

            if (target == root)
            {
                bfs(root, k);
            }
            else
            {
                backtrack(root);
                TreeNode _root = path[^1];
                bfs(_root, k);

                TreeNode node; int cnt = path.Count;
                for (int i = cnt - 2, j = 2; i >= 0 && k - j >= 0; i--, j++)
                {
                    node = path[i];
                    if (node.left != path[i + 1]) bfs(node.left, k - j); else bfs(node.right, k - j);
                }
                if (cnt - k - 1 >= 0) result.Add(path[cnt - k - 1].val);
            }

            return result;

            void bfs(TreeNode node, int steps)
            {
                if (node == null) return;

                queue.Clear();
                queue.Enqueue(node);
                int cnt; TreeNode item;
                while (steps-- > 0 && (cnt = queue.Count) > 0) for (int i = 0; i < cnt; i++)
                    {
                        item = queue.Dequeue();
                        if (item.left != null) queue.Enqueue(item.left);
                        if (item.right != null) queue.Enqueue(item.right);
                    }
                while (queue.Count > 0) result.Add(queue.Dequeue().val);
            }

            void backtrack(TreeNode node)
            {
                if (node == null) return;

                path.Add(node);
                if (node == target) return;
                backtrack(node.left);
                if (path[^1] == target) return;
                backtrack(node.right);
                if (path[^1] == target) return;
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
