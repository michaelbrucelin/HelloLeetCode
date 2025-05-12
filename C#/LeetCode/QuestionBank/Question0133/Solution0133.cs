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
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node CloneGraph(Node node)
        {
            Node _node = new Node(node.val);
            HashSet<Node> visited= new HashSet<Node>();

            return _node;
        }
    }
}
