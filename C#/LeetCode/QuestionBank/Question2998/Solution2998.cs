using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2998
{
    public class Solution2998 : Interface2998
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int MinimumOperationsToMakeEqual(int x, int y)
        {
            if (y >= x) return y - x;

            int result = 0;
            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(x);
            while (queue.Count > 0)
            {
                for (int i = queue.Count, _x, __x; i > 0; i--)
                {
                    if ((_x = queue.Dequeue()) == y) goto REACH;
                    if (_x < y)
                    {
                        if (!visited.Contains(__x = _x + 1)) { queue.Enqueue(__x); visited.Add(__x); }
                    }
                    else
                    {
                        if (!visited.Contains(__x = _x + 1)) { queue.Enqueue(__x); visited.Add(__x); }
                        if (!visited.Contains(__x = _x - 1)) { queue.Enqueue(__x); visited.Add(__x); }
                        if (_x % 05 == 0 && !visited.Contains(__x = _x / 05)) { queue.Enqueue(__x); visited.Add(__x); }
                        if (_x % 11 == 0 && !visited.Contains(__x = _x / 11)) { queue.Enqueue(__x); visited.Add(__x); }
                    }
                }
                result++;
            }
        REACH:;

            return result;
        }
    }
}
