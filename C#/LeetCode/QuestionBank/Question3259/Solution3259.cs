using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3259
{
    public class Solution3259 : Interface3259
    {
        /// <summary>
        /// DP
        /// F(N,0) = MAX(F(N-1,1), F(N-1,2))         第N项不获取能量
        /// F(N,1) = MAX(F(N-1,1), F(N-1,0)) + A(N)  第N项取能量A
        /// F(N,2) = MAX(F(N-1,2), F(N-1,0)) + B(N)  第N项取能量B
        /// </summary>
        /// <param name="energyDrinkA"></param>
        /// <param name="energyDrinkB"></param>
        /// <returns></returns>
        public long MaxEnergyBoost(int[] energyDrinkA, int[] energyDrinkB)
        {
            int len = energyDrinkA.Length;
            long[,] dp = new long[len, 3];
            dp[0, 0] = 0; dp[0, 1] = energyDrinkA[0]; dp[0, 2] = energyDrinkB[0];
            for (int i = 1; i < len; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 1], dp[i - 1, 2]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0]) + energyDrinkA[i];
                dp[i, 2] = Math.Max(dp[i - 1, 2], dp[i - 1, 0]) + energyDrinkB[i];
            }

            return Math.Max(dp[len - 1, 1], dp[len - 1, 2]);
        }

        /// <summary>
        /// 滚动数组
        /// </summary>
        /// <param name="energyDrinkA"></param>
        /// <param name="energyDrinkB"></param>
        /// <returns></returns>
        public long MaxEnergyBoost2(int[] energyDrinkA, int[] energyDrinkB)
        {
            int len = energyDrinkA.Length;
            long[,] dp = new long[2, 3];
            dp[1, 0] = 0; dp[1, 1] = energyDrinkA[0]; dp[1, 2] = energyDrinkB[0];
            for (int i = 1; i < len; i++)
            {
                dp[0, 0] = dp[1, 0]; dp[0, 1] = dp[1, 1]; dp[0, 2] = dp[1, 2];
                dp[1, 0] = Math.Max(dp[0, 1], dp[0, 2]);
                dp[1, 1] = Math.Max(dp[0, 1], dp[0, 0]) + energyDrinkA[i];
                dp[1, 2] = Math.Max(dp[0, 2], dp[0, 0]) + energyDrinkB[i];
            }

            return Math.Max(dp[1, 1], dp[1, 2]);
        }
    }
}
