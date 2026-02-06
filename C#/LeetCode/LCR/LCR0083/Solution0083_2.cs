using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0083
{
    public class Solution0083_2 : Interface0083
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = [];
            Queue<(List<int>, HashSet<int>)> queue = new Queue<(List<int>, HashSet<int>)>();
            queue.Enqueue(([], [.. nums]));
            List<int> list; HashSet<int> set;
            while (queue.Count > 0)
            {
                (list, set) = queue.Dequeue();
                if (set.Count == 0) { result.Add(list); continue; }
                foreach (int x in set)
                {
                    HashSet<int> _set = [.. set];
                    _set.Remove(x);
                    queue.Enqueue(([.. list, x], _set));
                }
            }

            return result;
        }
    }
}
