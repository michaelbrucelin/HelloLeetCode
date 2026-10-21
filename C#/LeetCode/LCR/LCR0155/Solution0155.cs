using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0155
{
    public class Solution0155 : Interface0155
    {
        /// <summary>
        /// DFS
        /// 中序遍历变形
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node TreeToDoublyList(Node root)
        {
            if (root == null) return root;
            if (root.left == null && root.right == null) return root.left = root.right = root;

            (Node head, Node tail) = dfs(root);
            head.left = tail;
            tail.right = head;
            return head;

            static (Node head, Node tail) dfs(Node node)
            {
                Node lhead, ltail, rhead, rtail;
                switch ((node.left, node.right))
                {
                    case (null, null):
                        return (node, node);
                    case (_, null):
                        (lhead, ltail) = dfs(node.left);
                        ltail.right = node; node.left = ltail;
                        return (lhead, node);
                    case (null, _):
                        (rhead, rtail) = dfs(node.right);
                        node.right = rhead; rhead.left = node;
                        return (node, rtail);
                    case (_, _):
                        (lhead, ltail) = dfs(node.left);
                        (rhead, rtail) = dfs(node.right);
                        ltail.right = node; node.left = ltail;
                        node.right = rhead; rhead.left = node;
                        return (lhead, rtail);
                }
            }
        }
    }
}
