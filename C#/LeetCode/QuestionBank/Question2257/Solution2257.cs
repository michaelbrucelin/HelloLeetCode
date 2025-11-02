using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2257
{
    public class Solution2257 : Interface2257
    {
        /// <summary>
        /// 遍历
        /// 如果一个位置没有被保护，即4个方向均没有被保护，所以4个方向查找一次即可
        /// 查找的时候只需要看相邻各自的状态即可
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="guards"></param>
        /// <param name="walls"></param>
        /// <returns></returns>
        public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
        {
            HashSet<(int, int)> _guards = new HashSet<(int, int)>();
            foreach (int[] guard in guards) _guards.Add((guard[0], guard[1]));
            HashSet<(int, int)> _walls = new HashSet<(int, int)>();
            foreach (int[] wall in walls) _walls.Add((wall[0], wall[1]));

            int[,] mask = new int[m, n];  // mask[i,j]右边起4位依次表示 上 下 左 右 4个方向是否被保卫
            // 上方
            for (int c = 0; c < n; c++) if (_guards.Contains((0, c))) mask[0, c] |= 1; else if (_walls.Contains((0, c))) mask[0, c] &= 14;
            for (int r = 1; r < m; r++) for (int c = 0; c < n; c++)
                {
                    if (_guards.Contains((r, c))) mask[r, c] |= 1;
                    else if (_walls.Contains((r, c))) mask[r, c] &= 14;
                    else mask[r, c] |= ((mask[r - 1, c] >> 0) & 1) << 0;
                }
            // 下方
            for (int c = 0; c < n; c++) if (_guards.Contains((m - 1, c))) mask[m - 1, c] |= 2; else if (_walls.Contains((m - 1, c))) mask[m - 1, c] &= 13;
            for (int r = m - 2; r >= 0; r--) for (int c = 0; c < n; c++)
                {
                    if (_guards.Contains((r, c))) mask[r, c] |= 2;
                    else if (_walls.Contains((r, c))) mask[r, c] &= 13;
                    else mask[r, c] |= ((mask[r + 1, c] >> 1) & 1) << 1;
                }
            // 左侧
            for (int r = 0; r < m; r++) if (_guards.Contains((r, 0))) mask[r, 0] |= 4; else if (_walls.Contains((r, 0))) mask[r, 0] &= 11;
            for (int c = 1; c < n; c++) for (int r = 0; r < m; r++)
                {
                    if (_guards.Contains((r, c))) mask[r, c] |= 4;
                    else if (_walls.Contains((r, c))) mask[r, c] &= 11;
                    else mask[r, c] |= ((mask[r, c - 1] >> 2) & 1) << 2;
                }
            // 右侧
            for (int r = 0; r < m; r++) if (_guards.Contains((r, n - 1))) mask[r, n - 1] |= 8; else if (_walls.Contains((r, n - 1))) mask[r, n - 1] &= 7;
            for (int c = n - 2; c >= 0; c--) for (int r = 0; r < m; r++)
                {
                    if (_guards.Contains((r, c))) mask[r, c] |= 8;
                    else if (_walls.Contains((r, c))) mask[r, c] &= 7;
                    else mask[r, c] |= ((mask[r, c + 1] >> 3) & 1) << 3;
                }

            int result = -walls.Length;
            for (int r = 0; r < m; r++) for (int c = 0; c < n; c++) result += ((mask[r, c] | -mask[r, c]) >> 31) + 1;
            return result;
        }
    }
}
