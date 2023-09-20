using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0872
{
    public class Solution0872_3 : Interface0872
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root1"></param>
        /// <param name="root2"></param>
        /// <returns></returns>
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            Queue<TreeNode> leafs1 = bfs(root1), leafs2 = bfs(root2);  // 题目限定root1 root2均不为null
            if (leafs1.Count != leafs2.Count) return false;
            while (leafs1.Count > 0) if (leafs1.Dequeue().val != leafs2.Dequeue().val) return false;

            return true;
        }

        private Queue<TreeNode> bfs(TreeNode node)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(node);
            bool flag = true; int cnt;
            while (flag)
            {
                flag = false; cnt = queue.Count;
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode _node = queue.Dequeue();
                    if (_node == null) continue;
                    if (_node.left == null && _node.right == null)
                        queue.Enqueue(_node);
                    else
                    {
                        flag = true;
                        queue.Enqueue(_node.left);
                        queue.Enqueue(_node.right);
                    }
                }
            }

            return queue;
        }
    }
}
