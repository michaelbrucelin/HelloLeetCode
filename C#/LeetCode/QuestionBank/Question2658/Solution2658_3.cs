using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2658
{
    public class Solution2658_3 : Interface2658
    {
        /// <summary>
        /// DisjointSet
        /// 二维并查集
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int FindMaxFish(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            UnionFind uf = new UnionFind(rcnt, ccnt);
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] > 0)
                    {
                        if (r > 0 && grid[r - 1][c] > 0) uf.Union(r, c, r - 1, c);
                        if (c > 0 && grid[r][c - 1] > 0) uf.Union(r, c, r, c - 1);
                    }

            Dictionary<(int, int), int> map = new Dictionary<(int, int), int>();
            int R, C;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] > 0)
                    {
                        (R, C) = uf.Find(r, c);
                        if (map.TryGetValue((R, C), out int t)) map[(R, C)] = t + grid[r][c]; else map.Add((R, C), grid[r][c]);
                    }

            int result = 0;
            foreach (int val in map.Values) result = Math.Max(result, val);
            return result;
        }

        public class UnionFind
        {
            public UnionFind(int rcnt, int ccnt)
            {
                uf = new (int, int)[rcnt, ccnt];
                height = new int[rcnt, ccnt];
                for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) uf[r, c] = (r, c);
            }

            private (int, int)[,] uf;
            private int[,] height;

            public void Union(int r1, int c1, int r2, int c2)
            {
                var (pr1, pc1) = Find(r1, c1);
                var (pr2, pc2) = Find(r2, c2);
                if (pr1 == pr2 && pc1 == pc2) return;

                if (height[pr1, pc1] == height[pr2, pc2])
                {
                    uf[pr2, pc2] = (pr1, pc1);
                    height[pr1, pc1]++;
                }
                else
                {
                    if (height[pr1, pc1] > height[pr2, pc2]) uf[pr2, pc2] = (pr1, pc1); else uf[pr1, pc1] = (pr2, pc2);
                }
            }

            public (int, int) Find(int r, int c)
            {
                if (uf[r, c] != (r, c)) uf[r, c] = Find(uf[r, c].Item1, uf[r, c].Item2);
                return uf[r, c];
            }
        }
    }
}
