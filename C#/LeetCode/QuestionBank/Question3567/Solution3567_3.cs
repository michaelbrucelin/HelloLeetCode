using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3567
{
    public class Solution3567_3 : Interface3567
    {
        /// <summary>
        /// 滑动窗口 + 有序字典
        /// 整体思路同Solution3567_2，改为有序字典做滑动窗口
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[][] MinAbsDiff(int[][] grid, int k)
        {
            int rcnt = grid.Length - k + 1, ccnt = grid[0].Length - k + 1;
            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++) result[r] = new int[ccnt];
            if (k == 1) return result;

            SortedDictionary<int, int> buffer_u = new SortedDictionary<int, int>();  // <value, count>
            SortedDictionary<int, int> buffer_l = new SortedDictionary<int, int>();  // buffer_u 上方, buffer_l 左侧

            for (int r = 0; r < k - 1; r++) for (int c = 0; c < k; c++) if (buffer_u.TryGetValue(grid[r][c], out int cnt)) buffer_u[grid[r][c]] = ++cnt; else buffer_u.Add(grid[r][c], 1);
            for (int r = 0, val, pre; r < rcnt; r++)
            {
                for (int _c = 0, _r = r + k - 1; _c < k; _c++) if (buffer_u.TryGetValue(grid[_r][_c], out int cnt)) buffer_u[grid[_r][_c]] = ++cnt; else buffer_u.Add(grid[_r][_c], 1);
                if (r > 0) for (int _c = 0, _r = r - 1; _c < k; _c++) if (buffer_u[grid[_r][_c]] == 1) buffer_u.Remove(grid[_r][_c]); else buffer_u[grid[_r][_c]]--;
                val = pre = int.MaxValue;
                foreach (int key in buffer_u.Keys) { if (pre != int.MaxValue) { val = Math.Min(val, key - pre); } pre = key; }
                result[r][0] = val == int.MaxValue ? 0 : val;
                buffer_l = new SortedDictionary<int, int>(buffer_u);

                for (int c = 1; c < ccnt; c++)
                {
                    for (int _r = r, _c = c + k - 1, R = r + k; _r < R; _r++) if (buffer_l.TryGetValue(grid[_r][_c], out int cnt)) buffer_l[grid[_r][_c]] = ++cnt; else buffer_l.Add(grid[_r][_c], 1);
                    for (int _r = r, _c = c - 1, R = r + k; _r < R; _r++) if (buffer_l[grid[_r][_c]] == 1) buffer_l.Remove(grid[_r][_c]); else buffer_l[grid[_r][_c]]--;
                    val = pre = int.MaxValue;
                    foreach (int key in buffer_l.Keys) { if (pre != int.MaxValue) { val = Math.Min(val, key - pre); } pre = key; }
                    result[r][c] = val == int.MaxValue ? 0 : val;
                }
            }

            return result;
        }
    }
}
