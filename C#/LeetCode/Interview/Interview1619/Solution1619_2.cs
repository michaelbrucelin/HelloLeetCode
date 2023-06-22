using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1619
{
    public class Solution1619_2 : Interface1619
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="land"></param>
        /// <returns></returns>
        public int[] PondSizes(int[][] land)
        {
            List<int> result = new List<int>();
            int rcnt = land.Length, ccnt = land[0].Length;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (land[r][c] != 0) continue;
                    result.Add(dfs(land, rcnt, ccnt, r, c));
                }

            result.Sort();
            return result.ToArray();
        }

        private int dfs(int[][] land, int rcnt, int ccnt, int r, int c)
        {
            if (land[r][c] != 0) return 0;

            int result = 1; land[r][c] = -1;
            for (int _r = -1; _r <= 1; _r++) for (int _c = -1; _c <= 1; _c++)
                {
                    int __r = r + _r, __c = c + _c;
                    if (__r >= 0 && __r < rcnt && __c >= 0 && __c < ccnt)
                    {
                        result += dfs(land, rcnt, ccnt, __r, __c);
                    }
                }

            return result;
        }
    }
}
