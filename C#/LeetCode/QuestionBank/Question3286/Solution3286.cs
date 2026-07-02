using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3286
{
    public class Solution3286 : Interface3286
    {
        /// <summary>
        /// Dijkstra
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="health"></param>
        /// <returns></returns>
        public bool FindSafeWalk(IList<IList<int>> grid, int health)
        {
            int sum = 0, rcnt = grid.Count, ccnt = grid[0].Count;
            if (rcnt == 1)
            {
                for (int c = 0; c < ccnt; c++) sum += grid[0][c];
                return sum < health;
            }
            if (ccnt == 1)
            {
                for (int r = 0; r < rcnt; r++) sum += grid[r][0];
                return sum < health;
            }

            int[] dirs = [-1, 0, 1, 0, -1];
            int[,] mins = new int[rcnt, ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) mins[r, c] = -1;
            mins[0, 0] = grid[0][0];
            PriorityQueue<(int, int, int), int> minpq = new PriorityQueue<(int, int, int), int>();
            minpq.Enqueue((0, 1, mins[0, 0] + grid[0][1]), mins[0, 0] + grid[0][1]);
            minpq.Enqueue((1, 0, mins[0, 0] + grid[1][0]), mins[0, 0] + grid[1][0]);
            int r1, c1, v1, r2, c2;
            while (minpq.Count > 0)
            {
                (r1, c1, v1) = minpq.Dequeue();
                if (mins[r1, c1] != -1) continue; mins[r1, c1] = v1;
                if (r1 == rcnt - 1 && c1 == ccnt - 1) break;
                for (int i = 0; i < 4; i++)
                {
                    r2 = r1 + dirs[i]; c2 = c1 + dirs[i + 1];
                    if (r2 < 0 || r2 >= rcnt || c2 < 0 || c2 >= ccnt || mins[r2, c2] != -1) continue;
                    minpq.Enqueue((r2, c2, v1 + grid[r2][c2]), v1 + grid[r2][c2]);
                }
            }

            return mins[rcnt - 1, ccnt - 1] < health;
        }
    }
}
