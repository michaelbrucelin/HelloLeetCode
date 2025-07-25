using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0133
{
    public class Solution0133_2 : Interface0133
    {
        /// <summary>
        /// BFS
        /// 逻辑同Solution0133，数组换成了字典，更通用
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node CloneGraph(Node node)
        {
            if (node == null) return null;
            Dictionary<Node, Node> cloned = new Dictionary<Node, Node>();

            // 克隆顶点
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);
            Node item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                if (cloned.ContainsKey(item)) continue;
                cloned.Add(item, new Node(item.val));
                foreach (Node next in item.neighbors) queue.Enqueue(next);
            }

            // 画边
            foreach (Node _node in cloned.Keys)
            {
                foreach (Node next in _node.neighbors) cloned[_node].neighbors.Add(cloned[next]);
            }

            return cloned[node];
        }
    }
}
