using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2368
{
    public class Solution2368_3 : Interface2368
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="restricted"></param>
        /// <returns></returns>
        public int ReachableNodes(int n, int[][] edges, int[] restricted)
        {
            HashSet<int> set = new HashSet<int>(restricted);
            if (set.Contains(0)) return 0;

            List<int>[] tree = new List<int>[n];
            for (int i = 0; i < n; i++) tree[i] = new List<int>();
            foreach (var edge in edges)
            {
                tree[edge[0]].Add(edge[1]); tree[edge[1]].Add(edge[0]);
            }

            int result = 0;
            Queue<(int id, int pre)> queue = new Queue<(int id, int pre)>();
            queue.Enqueue((0, -1)); (int id, int pre) item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                if (set.Contains(item.id)) continue;
                result++;
                foreach (int _id in tree[item.id]) if (_id != item.pre) queue.Enqueue((_id, item.id));
            }

            return result;
        }
    }
}
