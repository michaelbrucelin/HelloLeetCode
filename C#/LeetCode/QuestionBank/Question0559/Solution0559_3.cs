using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0559
{
    public class Solution0559_3 : Interface0559
    {
        public int MaxDepth(Node root)
        {
            if (root == null) return 0;

            int result = 0;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            int cnt; while ((cnt = queue.Count) > 0)
            {
                result++;
                for (int i = 0; i < cnt; i++)
                {
                    Node node = queue.Dequeue();
                    for (int j = 0; j < node.children.Count; j++)
                        queue.Enqueue(node.children[j]);
                }
            }

            return result;
        }
    }
}
