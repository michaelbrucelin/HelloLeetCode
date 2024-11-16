using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3240
{
    public class Solution3240 : Interface3240
    {
        /// <summary>
        /// 分析
        /// 1的数量总共分3部分，4个位置相同 + 2个位置相同（中线） + 1个位置相同（中心）
        /// 1. 既然行与列都是回文的，那么就是四个位置都需要相同
        ///     遍历左上角的全部单元格，每个单元格相对应的4个格子，至多翻转2次即可都相同
        ///     全部相同后，1的数量也一定是4的倍数
        /// 2. 如果1的数量不是4的倍数，问题也一定出现在“中线”上，单独分析“中线”上1与0的数量即可
        ///     中线采用Solution3219的方式操作，记录操作数以及1的数量，由于操作后回文，所以操作后中线上1的数量是偶数（除掉最中心那个点）
        ///     如果操作数 > 1，那么操作数不变，如果 操作数 % 4 = 2，那么将其中一次操作翻转后的值变一下就好
        ///     如果操作数 = 0，那么如果中线上1的数量如果除4余2，加两次操作即可
        /// 3. 中心点必须为0
        /// 
        /// 与Solution3240_err相比，问题反而简单了
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinFlips(int[][] grid)
        {
            int result1 = 0, result2 = 0, result3 = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            for (int r = 0, _cnt; r < rcnt / 2; r++) for (int c = 0; c < ccnt / 2; c++)
                {
                    _cnt = grid[r][c] + grid[rcnt - 1 - r][c] + grid[r][ccnt - 1 - c] + grid[rcnt - 1 - r][ccnt - 1 - c];
                    result1 += Math.Min(_cnt, 4 - _cnt);
                }

            int cnt0 = 0, cnt1 = 0;
            if ((rcnt & 1) == 1) for (int c = 0, r = rcnt / 2; c < ccnt / 2; c++)
                {
                    if (grid[r][c] != grid[r][ccnt - 1 - c]) result2++;
                    cnt1 += grid[r][c] + grid[r][ccnt - 1 - c]; cnt0 += 1 - grid[r][c] + 1 - grid[r][ccnt - 1 - c];
                }
            if ((ccnt & 1) == 1) for (int r = 0, c = ccnt / 2; r < rcnt / 2; r++)
                {
                    if (grid[r][c] != grid[rcnt - 1 - r][c]) result2++;
                    cnt1 += grid[r][c] + grid[rcnt - 1 - r][c]; cnt0 += 1 - grid[r][c] + 1 - grid[rcnt - 1 - r][c];
                }
            cnt1 %= 4;
            if (result2 == 0 && cnt1 != 0) result2 = 2;

            if ((rcnt & 1) == 1 && (ccnt & 1) == 1 && grid[rcnt / 2][ccnt / 2] == 1) result3 = 1;

            return result1 + result2 + result3;
        }
    }
}
