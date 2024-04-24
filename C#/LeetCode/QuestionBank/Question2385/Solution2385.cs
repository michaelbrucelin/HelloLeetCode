using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2385
{
    public class Solution2385 : Interface2385
    {
        /// <summary>
        /// BFS
        /// 如果根为start，那么直接BFS即可，否则将树转为无向图，BFS即可
        /// </summary>
        /// <param name="root"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public int AmountOfTime(TreeNode root, int start)
        {
            if (root == null) return 0;

            int result = -1;
            if (root.val == start)
            {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                int cnt; TreeNode node;
                while ((cnt = queue.Count) > 0)
                {
                    result++;
                    for (int i = 0; i < cnt; i++)
                    {
                        node = queue.Dequeue();
                        if (node.left != null) queue.Enqueue(node.left);
                        if (node.right != null) queue.Enqueue(node.right);
                    }
                }
            }
            else
            {
                // 将树转为图
                Dictionary<int, List<int>> grpah = new Dictionary<int, List<int>>();
                Queue<TreeNode> _queue = new Queue<TreeNode>();
                _queue.Enqueue(root);
                TreeNode node;
                while (_queue.Count > 0)
                {
                    node = _queue.Dequeue();
                    if (node.left != null)
                    {
                        grpah.TryAdd(node.val, new List<int>()); grpah[node.val].Add(node.left.val);
                        grpah.TryAdd(node.left.val, new List<int>()); grpah[node.left.val].Add(node.val);
                        _queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        grpah.TryAdd(node.val, new List<int>()); grpah[node.val].Add(node.right.val);
                        grpah.TryAdd(node.right.val, new List<int>()); grpah[node.right.val].Add(node.val);
                        _queue.Enqueue(node.right);
                    }
                }

                // BFS
                Queue<(int curr, int prev)> queue = new Queue<(int curr, int prev)>();
                queue.Enqueue((start, -1));
                int cnt; (int curr, int prev) item;
                while ((cnt = queue.Count) > 0)
                {
                    result++;
                    for (int i = 0; i < cnt; i++)
                    {
                        item = queue.Dequeue();
                        foreach (int next in grpah[item.curr]) if (next != item.prev)
                            {
                                queue.Enqueue((next, item.curr));
                            }
                    }
                }
            }

            return result;
        }
    }
}
