using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1970
{
    public class Solution1970 : Interface1970
    {
        /// <summary>
        /// 二分 + BFS
        /// 如果第n天可以，那么所有x(x<=n)天均可以，所以可以通过二分法找出答案
        /// 通过BFS验证第x天是否可以
        /// 预处理，标记上每个位置在哪一天变成水
        /// 
        /// 题目的本质就是找一条：起点在第一行终点在最后一行的路径，使路径中的最小值最大。
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="cells"></param>
        /// <returns></returns>
        public int LatestDayToCross(int row, int col, int[][] cells)
        {
            int result = -1, cnt = row * col;
            int[,] states = new int[row, col];
            for (int i = 0; i < cnt; i++) states[cells[i][0] - 1, cells[i][1] - 1] = i + 1;
            Queue<(int, int)> queue = new Queue<(int, int)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            int[] dirs = [-1, 0, 1, 0, -1];

            int low = 1, high = cnt - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (Check(mid)) { result = mid; low = mid + 1; } else { high = mid - 1; }
            }

            return result;

            bool Check(int x)
            {
                queue.Clear(); visited.Clear();
                for (int i = 0; i < col; i++) if (states[0, i] > x)
                    {
                        queue.Enqueue((0, i)); visited.Add((0, i));
                    }

                int r, c, _r, _c;
                while (queue.Count > 0)
                {
                    (r, c) = queue.Dequeue();
                    for (int i = 0; i < 4; i++)
                    {
                        _r = r + dirs[i]; _c = c + dirs[i + 1];
                        if (_r >= 0 && _r < row && _c >= 0 && _c < col && states[_r, _c] > x && !visited.Contains((_r, _c)))
                        {
                            if (_r == row - 1) return true;
                            queue.Enqueue((_r, _c)); visited.Add((_r, _c));
                        }
                    }
                }

                return false;
            }
        }
    }
}
