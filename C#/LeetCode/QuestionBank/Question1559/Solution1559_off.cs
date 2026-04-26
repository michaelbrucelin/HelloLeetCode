using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1559
{
    public class Solution1559_off : Interface1559
    {
        public bool ContainsCycle(char[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            (int, int)[,] uf = new (int, int)[rcnt, ccnt];
            int[,] rank = new int[rcnt, ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) uf[r, c] = (r, c);
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (r - 1 >= 0 && grid[r - 1][c] == grid[r][c] && union(r, c, r - 1, c)) return true;
                    if (c - 1 >= 0 && grid[r][c - 1] == grid[r][c] && union(r, c, r, c - 1)) return true;
                }

            return false;

            (int, int) find(int r, int c)
            {
                if (uf[r, c] != (r, c)) uf[r, c] = find(uf[r, c].Item1, uf[r, c].Item2);
                return uf[r, c];
            }

            bool union(int r1, int c1, int r2, int c2)
            {
                (r1, c1) = find(r1, c1);
                (r2, c2) = find(r2, c2);
                if (r1 == r2 && c1 == c2) return true;
                switch (rank[r1, c1] - rank[r2, c2])
                {
                    case > 0: uf[r2, c2] = (r1, c1); break;
                    case < 0: uf[r1, c1] = (r2, c2); break;
                    default: uf[r2, c2] = (r1, c1); rank[r1, c1]++; break;
                }

                return false;
            }
        }
    }
}
