using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3459
{
    public class Solution3459_err : Interface3459
    {
        /// <summary>
        /// DFS
        /// 四个可前进方向分别为 (1,1), (1,-1), (-1,1), (-1,-1)
        /// 转弯是将方向的其中一项 * -1，例如 (1,1) 可以转向 (1,-1) 与 (-1,1)
        /// 
        /// 题目限定最多一次顺时针90度转向，而代码实现的是最多一次90度转向
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int LenOfVDiagonal(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            int[] dirs = [1, 1, -1, -1, 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] == 1)
                    {
                        result = Math.Max(result, dfs((r, c), (0, 0), 1, true));
                    }

            return result;

            int dfs((int r, int c) pos, (int r, int c) move, int target, bool canchange)
            {
                if (pos.r < 0 || pos.r >= rcnt || pos.c < 0 || pos.c >= ccnt || grid[pos.r][pos.c] != target) return 0;

                int result = 0;
                target = 3 - (grid[pos.r][pos.c] | 1);  // 1->2, 2->0, 0->2
                if (grid[pos.r][pos.c] == 1)
                {
                    for (int i = 0; i < 4; i++) result = Math.Max(result, dfs((pos.r + dirs[i], pos.c + dirs[i + 1]), (dirs[i], dirs[i + 1]), target, true));
                }
                else
                {
                    result = dfs((pos.r + move.r, pos.c + move.c), move, target, canchange);
                    if (canchange)
                    {
                        result = Math.Max(result, dfs((pos.r + move.r, pos.c - move.c), (move.r, -move.c), target, false));
                        result = Math.Max(result, dfs((pos.r - move.r, pos.c + move.c), (-move.r, move.c), target, false));
                    }
                }

                return result + 1;
            }
        }
    }
}
