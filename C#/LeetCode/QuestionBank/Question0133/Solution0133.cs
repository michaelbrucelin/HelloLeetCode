using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0133
{
    public class Solution0133 : Interface0133
    {
        /// <summary>
        /// DFS
        /// 第一次DFS克隆出每一个顶点，第二次DFS还原每个顶点的边
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node CloneGraph(Node node)
        {
            if (node == null) return null;
            Node[] cloned = new Node[101];
            bool[] visited = new bool[101];
            dfs1(node);
            dfs2(node);
            return cloned[node.val];

            void dfs1(Node node)
            {
                if (cloned[node.val] != null) return;
                Node _node = new Node(node.val);
                cloned[node.val] = _node;
                foreach (Node next in node.neighbors) dfs1(next);
            }

            void dfs2(Node node)
            {
                if (visited[node.val]) return;
                foreach (Node next in node.neighbors) cloned[node.val].neighbors.Add(cloned[next.val]);
                visited[node.val] = true;
                foreach (Node next in node.neighbors) dfs2(next);
            }
        }
    }
}
