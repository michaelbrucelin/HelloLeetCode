using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0138
{
    public class Solution0138 : Interface0138
    {
        /// <summary>
        /// 遍历
        /// 本质上就是克隆一个有向连通图
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node CopyRandomList(Node head)
        {
            if (head == null) return null;

            // 克隆节点
            Dictionary<Node, Node> cloned = new Dictionary<Node, Node>();
            Node ptr = head;
            while (ptr != null)
            {
                Node _node = new Node(ptr.val);
                cloned.Add(ptr, _node);
                ptr = ptr.next;
            }

            // 描边
            foreach (Node node in cloned.Keys)
            {
                if (node.next != null) cloned[node].next = cloned[node.next];
                if (node.random != null) cloned[node].random = cloned[node.random];
            }

            return cloned[head];
        }
    }
}
