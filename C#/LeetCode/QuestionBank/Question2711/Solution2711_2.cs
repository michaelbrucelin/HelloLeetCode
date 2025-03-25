using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2711
{
    public class Solution2711_2 : Interface2711
    {
        /// <summary>
        /// 逐个对角线遍历
        /// 这样时间复杂度比较低，由于这道题目的数据量较小，没有太大意义，如果数据量较大这样做就有用了
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] DifferenceOfDistinctValues(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++) result[r] = new int[ccnt];

            HashSet<int> lt = new HashSet<int>();
            Dictionary<int, int> rb = new Dictionary<int, int>();
            for (int c = 0; c < ccnt; c++)
            {
                lt.Clear(); rb.Clear();
                for (int r = 1, v; r < rcnt && c + r < ccnt; r++)
                {
                    v = grid[r][c + r];
                    if (rb.ContainsKey(v)) rb[v]++; else rb.Add(v, 1);
                }
                result[0][c] = rb.Count;
                for (int r = 1; r < rcnt && c + r < ccnt; r++)
                {
                    if (--rb[grid[r][c + r]] == 0) rb.Remove(grid[r][c + r]);
                    lt.Add(grid[r - 1][c + r - 1]);
                    result[r][c + r] = Math.Abs(lt.Count - rb.Count);
                }
            }
            for (int r = 1; r < rcnt; r++)
            {
                lt.Clear(); rb.Clear();
                for (int c = 1, v; c < ccnt && r + c < rcnt; c++)
                {
                    v = grid[r + c][c];
                    if (rb.ContainsKey(v)) rb[v]++; else rb.Add(v, 1);
                }
                result[r][0] = rb.Count;
                for (int c = 1; c < ccnt && r + c < rcnt; c++)
                {
                    if (--rb[grid[r + c][c]] == 0) rb.Remove(grid[r + c][c]);
                    lt.Add(grid[r + c - 1][c - 1]);
                    result[r + c][c] = Math.Abs(lt.Count - rb.Count);
                }
            }

            return result;
        }
    }
}
