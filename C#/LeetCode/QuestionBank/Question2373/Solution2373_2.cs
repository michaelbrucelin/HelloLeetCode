using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2373
{
    public class Solution2373_2 : Interface2373
    {
        /// <summary>
        /// 一次滑动窗口
        /// 一次二维滑动窗口，使用有序字典来维护每个窗口，每个窗口是一个3*3的二维数组
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] LargestLocal(int[][] grid)
        {
            int len = grid.Length;
            int[][] result = new int[len - 2][];
            for (int i = 0; i < len - 2; i++) result[i] = new int[len - 2];
            var comparer = Comparer<int>.Create((i1, i2) => i2 - i1);
            SortedDictionary<int, int> window = new SortedDictionary<int, int>(comparer);
            for (int r = 0; r < 3; r++) for (int c = 0; c < 3; c++) { int val = grid[r][c]; window.TryAdd(val, 0); window[val]++; }

            for (int r = 0; r < len - 2; r++)
            {
                if (r > 0)
                {
                    for (int _c = 0; _c < 3; _c++) { int val = grid[r + 2][_c]; window.TryAdd(val, 0); window[val]++; }
                    for (int _c = 0; _c < 3; _c++) { int val = grid[r - 1][_c]; if (window[val] == 1) window.Remove(val); else window[val]--; }
                }
                SortedDictionary<int, int> _window = new SortedDictionary<int, int>(window, comparer);
                result[r][0] = _window.First().Key;
                for (int c = 1; c < len - 2; c++)
                {
                    for (int _r = r; _r <= r + 2; _r++) { int val = grid[_r][c + 2]; _window.TryAdd(val, 0); _window[val]++; }
                    for (int _r = r; _r <= r + 2; _r++) { int val = grid[_r][c - 1]; if (_window[val] == 1) _window.Remove(val); else _window[val]--; }
                    result[r][c] = _window.First().Key;
                }
            }

            return result;
        }

        /// <summary>
        /// 二维滑动窗口
        /// 与LargestLocal()逻辑一样，将窗口由有序字典改为优先级队列
        /// 
        /// 这个解法是错误的，因为没有即时的将应该移除队列的元素移除
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] LargestLocal2(int[][] grid)
        {
            int len = grid.Length;
            int[][] result = new int[len - 2][];
            for (int i = 0; i < len - 2; i++) result[i] = new int[len - 2];
            var comparer = Comparer<int>.Create((i1, i2) => i2 - i1);
            PriorityQueue<int, int> window = new PriorityQueue<int, int>();
            for (int r = 0; r < 3; r++) for (int c = 0; c < 3; c++) window.Enqueue(grid[r][c], -grid[r][c]);

            for (int r = 0; r < len - 2; r++)
            {
                if (r > 0)
                {
                    for (int _c = 0; _c < 3; _c++) window.Enqueue(grid[r + 2][_c], -grid[r + 2][_c]);
                    for (int _c = 0; _c < 3; _c++) if (window.Peek() == grid[r - 1][_c]) window.Dequeue();         // 这个解法是错误的，因为没有即时的将应该移除队列的元素移除
                }
                PriorityQueue<int, int> _window = new PriorityQueue<int, int>(window.UnorderedItems);
                result[r][0] = _window.Peek();
                for (int c = 1; c < len - 2; c++)
                {
                    for (int _r = r; _r <= r + 2; _r++) _window.Enqueue(grid[_r][c + 2], -grid[_r][c + 2]);
                    for (int _r = r; _r <= r + 2; _r++) if (_window.Peek() == grid[_r][c - 1]) _window.Dequeue();  // 这个解法是错误的，因为没有即时的将应该移除队列的元素移除
                    result[r][c] = _window.Peek();
                }
            }

            return result;
        }
    }
}
