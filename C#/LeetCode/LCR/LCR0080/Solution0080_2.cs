using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0080
{
    public class Solution0080_2 : Interface0080
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> result = [];
            Queue<(List<int>, int)> queue = new Queue<(List<int>, int)>();
            queue.Enqueue(([], 1));
            List<int> list; int _n;
            while (queue.Count > 0)
            {
                (list, _n) = queue.Dequeue();
                if (list.Count == k) { result.Add(list); continue; }
                if (n - _n + 1 < k - list.Count) continue;
                queue.Enqueue(([.. list, _n], _n + 1));
                queue.Enqueue((list, _n + 1));
            }

            return result;
        }
    }
}
