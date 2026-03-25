using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3546
{
    public class Solution3546 : Interface3546
    {
        /// <summary>
        /// 预处理
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public bool CanPartitionGrid(int[][] grid)
        {
            long sum = 0; int rcnt = grid.Length, ccnt = grid[0].Length;
            long[] rsum = new long[rcnt], csum = new long[ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    sum += grid[r][c]; rsum[r] += grid[r][c]; csum[c] += grid[r][c];
                }
            if ((sum & 1) == 1) return false;
            sum >>= 1; long _sum = 0;
            for (int r = 0; r < rcnt && _sum <= sum; r++) if ((_sum += rsum[r]) == sum) return true;
            _sum = 0;
            for (int c = 0; c < ccnt && _sum <= sum; c++) if ((_sum += csum[c]) == sum) return true;

            return false;
        }
    }
}
