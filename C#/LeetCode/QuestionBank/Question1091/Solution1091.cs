using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1091
{
    public class Solution1091 : Interface1091
    {
        // 可以使用两层循环的`for(int _r=-1; _r<=1; _r++) for(int _c=-1; _c<=1; _c++)`，但是两层循环会验证到自身（_r=1, _c=0）
        private static readonly (int r, int c)[] dir = new (int r, int c)[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };

        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            int len = grid.Length;
            if (grid[0][0] == 1 || grid[len - 1][len - 1] == 1) return -1;
            if (len == 1) return 1;

            int result = 1;
            bool[,] visited = new bool[len, len]; visited[0, 0] = true;
            for (int r = 0; r < len; r++) for (int c = 0; c < len; c++) if (grid[r][c] == 1) visited[r, c] = true;
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>(); queue.Enqueue((0, 0));
            int cnt, _r, _c; while ((cnt = queue.Count) > 0)
            {
                result++;
                for (int i = 0; i < cnt; i++)
                {
                    var point = queue.Dequeue();
                    foreach (var _dir in dir)
                    {
                        _r = point.r + _dir.r; _c = point.c + _dir.c;
                        if (_r >= 0 && _r < len && _c >= 0 && _c < len && !visited[_r, _c])
                        {
                            if (_r == len - 1 && _c == len - 1) return result;
                            visited[_r, _c] = true;
                            queue.Enqueue((_r, _c));
                        }
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// 与ShortestPathBinaryMatrix()一样，做了如下两处更改
        /// 1. 没有使用visited数组做掩码，而是直接更改grid中的0为1
        /// 2. 没有使用dir数组，而是直接两层循环遍历8个方向
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ShortestPathBinaryMatrix2(int[][] grid)
        {
            int len = grid.Length;
            if (grid[0][0] == 1 || grid[len - 1][len - 1] == 1) return -1;
            if (len == 1) return 1;

            int result = 1;
            grid[0][0] = 1;
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>(); queue.Enqueue((0, 0));
            int cnt, _r, _c; while ((cnt = queue.Count) > 0)
            {
                result++;
                for (int i = 0; i < cnt; i++)
                {
                    var point = queue.Dequeue();
                    for (int __r = -1; __r <= 1; __r++) for (int __c = -1; __c <= 1; __c++)
                        {
                            _r = point.r + __r; _c = point.c + __c;
                            if (_r >= 0 && _r < len && _c >= 0 && _c < len && grid[_r][_c] == 0)
                            {
                                if (_r == len - 1 && _c == len - 1) return result;
                                grid[_r][_c] = 1;
                                queue.Enqueue((_r, _c));
                            }
                        }
                }
            }

            return -1;
        }
    }
}
