using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3459
{
    public class Solution3459_2 : Interface3459
    {
        /// <summary>
        /// DFS + DP预处理 + 剪枝
        /// 逻辑同Solution3459，提前预处理出每个位置4个方向的（不转弯）的最长距离
        /// 预处理可以借助dp来完成
        /// 可能最大值为Math.Min(Math.Min(rcnt, ccnt) * 2 - 1, Math.Max(rcnt, ccnt))，所以如果提前拿到了最大值，可以直接返回
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int LenOfVDiagonal(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            int limit = Math.Min(Math.Min(rcnt, ccnt) * 2 - 1, Math.Max(rcnt, ccnt));
            int[,,] dp = new int[rcnt, ccnt, 4];  // 0 左上 1 右上 2 左下 3 右下
            int target;
            for (int c = 0; c < ccnt; c++) dp[0, c, 0] = dp[0, c, 1] = 1;
            for (int r = 1; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    target = 3 - (grid[r][c] | 1);  // 1->2, 2->0, 0->2
                    dp[r, c, 0] = 1; if (c - 1 >= 0 && grid[r - 1][c - 1] == target) dp[r, c, 0] += dp[r - 1, c - 1, 0];
                    dp[r, c, 1] = 1; if (c + 1 < ccnt && grid[r - 1][c + 1] == target) dp[r, c, 1] += dp[r - 1, c + 1, 1];
                }
            for (int c = 0; c < ccnt; c++) dp[rcnt - 1, c, 2] = dp[rcnt - 1, c, 3] = 1;
            for (int r = rcnt - 2; r >= 0; r--) for (int c = 0; c < ccnt; c++)
                {
                    target = 3 - (grid[r][c] | 1);  // 1->2, 2->0, 0->2
                    dp[r, c, 2] = 1; if (c - 1 >= 0 && grid[r + 1][c - 1] == target) dp[r, c, 2] += dp[r + 1, c - 1, 2];
                    dp[r, c, 3] = 1; if (c + 1 < ccnt && grid[r + 1][c + 1] == target) dp[r, c, 3] += dp[r + 1, c + 1, 3];
                }

            int[] dirs = [1, 1, -1, -1, 1];
            Dictionary<(int r, int c), int> map = new Dictionary<(int r, int c), int> { { (-1, -1), 0 }, { (-1, 1), 1 }, { (1, -1), 2 }, { (1, 1), 3 } };
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] == 1)
                    {
                        result = Math.Max(result, dfs((r, c), (0, 0), 1, true));
                        if (result == limit) goto FOUND;
                    }
                FOUND:;

            return result;

            int dfs((int r, int c) pos, (int r, int c) move, int target, bool canchange)
            {
                if (pos.r < 0 || pos.r >= rcnt || pos.c < 0 || pos.c >= ccnt || grid[pos.r][pos.c] != target) return 0;

                int result = 0;
                target = 3 - (grid[pos.r][pos.c] | 1);  // 1->2, 2->0, 0->2
                if (grid[pos.r][pos.c] == 1)
                {
                    for (int i = 0; i < 4; i++) result = Math.Max(result, dfs((pos.r + dirs[i], pos.c + dirs[i + 1]), (dirs[i], dirs[i + 1]), target, true));
                    result += 1;
                }
                else
                {
                    if (canchange)
                    {
                        result = dfs((pos.r + move.r, pos.c + move.c), move, target, true);
                        if (move.r == move.c)
                            result = Math.Max(result, dfs((pos.r + move.r, pos.c - move.c), (move.r, -move.c), target, false));
                        else
                            result = Math.Max(result, dfs((pos.r - move.r, pos.c + move.c), (-move.r, move.c), target, false));
                        result += 1;
                    }
                    else
                    {
                        result = dp[pos.r, pos.c, map[move]];
                    }
                }

                return result;
            }
        }
    }
}
