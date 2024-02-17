using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0429
{
    public class Solution0429 : Interface0429
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(Node root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            int cnt; Node node;
            while ((cnt = queue.Count) > 0)
            {
                List<int> list = new List<int>();
                for (int i = 0; i < cnt; i++)
                {
                    node = queue.Dequeue();
                    list.Add(node.val);
                    if (node.children != null) for (int j = 0; j < node.children.Count; j++)
                        {
                            queue.Enqueue(node.children[j]);
                        }
                }
                result.Add(list);
            }

            return result;
        }
    }
}
