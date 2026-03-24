using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2906
{
    public class Solution2906 : Interface2906
    {
        /// <summary>
        /// 前缀积
        /// 利用类BigInteger来简化运算
        /// 
        /// 逻辑没问题，TLE，速度比想象中的低的太多了，参考测试用例03
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] ConstructProductMatrix(int[][] grid)
        {
            int MOD = 12345, rcnt = grid.Length, ccnt = grid[0].Length;
            BigInteger product = 1;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) product *= grid[r][c];

            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++) result[r] = new int[ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) result[r][c] = (int)(product / grid[r][c] % MOD);

            return result;
        }
    }
}
