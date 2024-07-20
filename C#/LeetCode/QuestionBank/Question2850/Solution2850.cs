using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2850
{
    public class Solution2850 : Interface2850
    {
        /// <summary>
        /// 暴力枚举，排列组合
        /// 1. 从A移到B需要移动|x1-x2|+|y1-y2|次
        /// 2. 最多有8个起点（都在一起，是一个起点），8个终点，一共8！=40320种可能
        /// 3. 枚举全部可能：
        ///     起点不动，枚举全部终点的顺序，然后与起点配对即可
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinimumMoves(int[][] grid)
        {
            List<(int r, int c)> start = new List<(int r, int c)>(), end = new List<(int r, int c)>();
            for (int r = 0; r < 3; r++) for (int c = 0; c < 3; c++) switch (grid[r][c])
                    {
                        case 0:
                            end.Add((r, c));
                            break;
                        case > 1:
                            for (int i = 1; i < grid[r][c]; i++) start.Add((r, c));
                            break;
                    }
            if (start.Count == 0) return 0;

            int result = int.MaxValue, _result;
            rec(end, 0, start.Count - 1);
            return result;

            // 全排列
            void rec(List<(int r, int c)> list, int l, int r)
            {
                if (l == r)
                {
                    _result = 0;
                    for (int i = 0; i < start.Count; i++) _result += Math.Abs(start[i].r - end[i].r) + Math.Abs(start[i].c - end[i].c);
                    result = Math.Min(result, _result);
                }
                else
                {
                    for (int i = l; i <= r; i++)
                    {
                        var temp = list[l]; list[l] = list[i]; list[i] = temp;
                        rec(list, l + 1, r);
                        temp = list[l]; list[l] = list[i]; list[i] = temp;
                    }
                }
            }
        }
    }
}
