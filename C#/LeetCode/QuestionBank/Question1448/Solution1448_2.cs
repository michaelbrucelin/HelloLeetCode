using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1448
{
    public class Solution1448_2 : Interface1448
    {
        /// <summary>
        /// bfs
        /// 单一队列，逐层处理，可以明确的知道当前在第几层
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int GoodNodes(TreeNode root)
        {
            int result = 0;
            Queue<(TreeNode node, int max)> queue = new Queue<(TreeNode node, int max)>();
            queue.Enqueue((root, -10001));  // -10001是哨兵
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    var t = queue.Dequeue();
                    if (t.node.val >= t.max)
                    {
                        result++; t.max = t.node.val;
                    }
                    if (t.node.left != null) queue.Enqueue((t.node.left, t.max));
                    if (t.node.right != null) queue.Enqueue((t.node.right, t.max));
                }
            }

            return result;
        }

        /// <summary>
        /// bfs
        /// 双队列，逐个处理，不知道当前在第几层
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int GoodNodes2(TreeNode root)
        {
            int result = 0;
            Queue<TreeNode> queue1 = new Queue<TreeNode>(); queue1.Enqueue(root);
            Queue<int> queue2 = new Queue<int>(); queue2.Enqueue(-10001);  // -10001是哨兵
            TreeNode node; int max;
            while (queue1.Count > 0)
            {
                node = queue1.Dequeue(); max = queue2.Dequeue();
                if (node.val >= max)
                {
                    result++; max = node.val;
                }
                if (node.left != null) { queue1.Enqueue(node.left); queue2.Enqueue(max); }
                if (node.right != null) { queue1.Enqueue(node.right); queue2.Enqueue(max); }
            }

            return result;
        }
    }
}
