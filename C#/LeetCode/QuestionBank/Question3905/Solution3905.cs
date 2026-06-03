using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3905
{
    public class Solution3905 : Interface3905
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="sources"></param>
        /// <returns></returns>
        public int[][] ColorGrid(int n, int m, int[][] sources)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++) result[i] = new int[m];
            foreach (int[] init in sources) result[init[0]][init[1]] = init[2];

            int[] dirs = [-1, 0, 1, 0, -1];
            Queue<(int, int)> queue = new Queue<(int, int)>();
            Dictionary<(int, int), int> buffer = new Dictionary<(int, int), int>();
            for (int r = 0; r < n; r++) for (int c = 0; c < m; c++) if (result[r][c] != 0) queue.Enqueue((r, c));
            int pr, pc, _r, _c;
            while (queue.Count > 0)
            {
                for (int i = queue.Count; i > 0; i--)
                {
                    (pr, pc) = queue.Dequeue();
                    for (int j = 0; j < 4; j++)
                    {
                        _r = pr + dirs[j]; _c = pc + dirs[j + 1];
                        if (_r < 0 || _r >= n || _c < 0 || _c >= m || result[_r][_c] != 0) continue;
                        buffer.TryAdd((_r, _c), 0);
                        buffer[(_r, _c)] = Math.Max(buffer[(_r, _c)], result[pr][pc]);
                    }
                }
                foreach (var kv in buffer)
                {
                    result[kv.Key.Item1][kv.Key.Item2] = kv.Value;
                    queue.Enqueue((kv.Key.Item1, kv.Key.Item2));
                }
                buffer.Clear();
            }

            return result;
        }
    }
}
