using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0589
{
    public class Solution0589_3 : Interface0589
    {
        /// <summary>
        /// 迭代
        /// 栈中记录子节点列表以及已处理的id
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder(Node root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            result.Add(root.val);
            Stack<(IList<Node> nodes, int id)> stack = new Stack<(IList<Node> nodes, int id)>();
            stack.Push((root.children, 0));
            while (stack.Count > 0)
            {
                var t = stack.Pop();
                if (t.nodes == null || t.id >= t.nodes.Count) continue;
                Node node = t.nodes[t.id];
                result.Add(node.val);
                stack.Push((t.nodes, t.id + 1));
                stack.Push((node.children, 0));
            }

            return result;
        }
    }
}
