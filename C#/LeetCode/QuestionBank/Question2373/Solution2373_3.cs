using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2373
{
    public class Solution2373_3 : Interface2373
    {
        /// <summary>
        /// 两次滑动窗口
        /// 两次一维滑动窗口，使用有序字典来维护每个窗口，每个窗口是一个长度为3的一维数组
        /// 第1次，数组每一行横向滑动窗口
        /// 第2次，数组每一列纵向滑动窗口
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] LargestLocal(int[][] grid)
        {
            int len = grid.Length;
            var comparer = Comparer<int>.Create((i1, i2) => i2 - i1);

            // 第1次滑动窗口
            int[][] temp = new int[len][];
            for (int i = 0; i < len; i++) temp[i] = new int[len - 2];
            for (int r = 0; r < len; r++)
            {
                SortedDictionary<int, int> buffer = new SortedDictionary<int, int>(comparer);
                for (int c = 0; c < 3; c++) { buffer.TryAdd(grid[r][c], 0); buffer[grid[r][c]]++; }
                temp[r][0] = buffer.First().Key;
                for (int c = 1; c < len - 2; c++)
                {
                    buffer.TryAdd(grid[r][c + 2], 0); buffer[grid[r][c + 2]]++;
                    if (buffer[grid[r][c - 1]] == 1) buffer.Remove(grid[r][c - 1]); else buffer[grid[r][c - 1]]--;
                    temp[r][c] = buffer.First().Key;
                }
            }

            // 第2次滑动窗口
            int[][] result = new int[len - 2][];
            for (int i = 0; i < len - 2; i++) result[i] = new int[len - 2];
            for (int c = 0; c < len - 2; c++)
            {
                SortedDictionary<int, int> buffer = new SortedDictionary<int, int>(comparer);
                for (int r = 0; r < 3; r++) { buffer.TryAdd(temp[r][c], 0); buffer[temp[r][c]]++; }
                result[0][c] = buffer.First().Key;
                for (int r = 1; r < len - 2; r++)
                {
                    buffer.TryAdd(temp[r + 2][c], 0); buffer[temp[r + 2][c]]++;
                    if (buffer[temp[r - 1][c]] == 1) buffer.Remove(temp[r - 1][c]); else buffer[temp[r - 1][c]]--;
                    result[r][c] = buffer.First().Key;
                }
            }

            return result;
        }
    }
}
