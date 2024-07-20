using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2850
{
    public class Solution2850_2 : Interface2850
    {
        /// <summary>
        /// 逻辑与Solution2850一样，只是换成字典序生成全排列
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinimumMoves(int[][] grid)
        {
            List<(int r, int c, int i)> start = new List<(int r, int c, int i)>(), end = new List<(int r, int c, int i)>();
            for (int r = 0; r < 3; r++) for (int c = 0; c < 3; c++) switch (grid[r][c])
                    {
                        case 0:
                            end.Add((r, c, r * 3 + c));
                            break;
                        case > 1:
                            for (int i = 1; i < grid[r][c]; i++) start.Add((r, c, r * 3 + c));
                            break;
                    }
            if (start.Count == 0) return 0;

            int result = int.MaxValue, _result;
            end.Sort((x, y) => x.i - y.i);
            do
            {
                _result = 0;
                for (int i = 0; i < start.Count; i++) _result += Math.Abs(start[i].r - end[i].r) + Math.Abs(start[i].c - end[i].c);
                result = Math.Min(result, _result);
            } while (NextPermutation(end));

            return result;

            // 下一个字典序
            bool NextPermutation(List<(int r, int c, int i)> list)
            {
                int cnt = list.Count, i = cnt - 2;

                while (i >= 0 && list[i].i >= list[i + 1].i) i--;
                if (i < 0) return false;
                int j = cnt - 1;
                while (list[j].i <= list[i].i) j--;
                Swap(list, i, j);
                Reverse(list, i + 1, cnt - 1);

                return true;
            }

            void Swap(List<(int r, int c, int i)> list, int i, int j)
            {
                var temp = list[i]; list[i] = list[j]; list[j] = temp;
            }

            void Reverse(List<(int r, int c, int i)> list, int start, int end)
            {
                while (start < end)
                {
                    Swap(list, start, end); start++; end--;
                }
            }
        }
    }
}
