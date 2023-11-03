using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0116
{
    public class Solution0116 : Interface0116
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect(Node root)
        {
            if (root == null) return root;

            Queue<Node> queue = new Queue<Node>(); queue.Enqueue(root);
            int cnt; Node node;
            while ((cnt = queue.Count) > 0)
            {
                node = queue.Dequeue(); cnt--;
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
                for (int i = 0; i < cnt; i++)
                {
                    node.next = queue.Dequeue(); node = node.next;
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                // node.next = null;
            }

            return root;
        }

        /// <summary>
        /// BFS
        /// 充分利用“完美二叉树”这个条件，即每一层都是满的
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect2(Node root)
        {
            if (root == null) return root;

            Queue<Node> queue = new Queue<Node>(); queue.Enqueue(root);
            int cnt; Node node = new Node();
            while ((cnt = queue.Count) > 0)
            {
                node = queue.Dequeue(); cnt--;
                if (node.left == null) goto LastLevel;
                queue.Enqueue(node.left); queue.Enqueue(node.right);
                for (int i = 0; i < cnt; i++)
                {
                    node.next = queue.Dequeue(); node = node.next;
                    queue.Enqueue(node.left); queue.Enqueue(node.right);
                }
            }
            LastLevel:
            for (int i = 0; i < cnt; i++)
            {
                node.next = queue.Dequeue(); node = node.next;
            }

            return root;
        }
    }
}
