using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3259
{
    public class Solution3259_2 : Interface3259
    {
        /// <summary>
        /// DP
        /// 本质上同Solution3259，但是不需要记录3个状态，只要记录两个状态就可以了
        /// F(N,1) = MAX(F(N-1,1), F(N-2,2)) + A(N)  第N项取能量A
        /// F(N,2) = MAX(F(N-1,2), F(N-2,1)) + B(N)  第N项取能量B
        /// </summary>
        /// <param name="energyDrinkA"></param>
        /// <param name="energyDrinkB"></param>
        /// <returns></returns>
        public long MaxEnergyBoost(int[] energyDrinkA, int[] energyDrinkB)
        {
            int len = energyDrinkA.Length;
            long[,] dp = new long[len + 1, 2];
            dp[1, 0] = energyDrinkA[0]; dp[1, 1] = energyDrinkB[0];
            for (int i = 1; i < len; i++)
            {
                dp[i + 1, 0] = Math.Max(dp[i, 0], dp[i - 1, 1]) + energyDrinkA[i];
                dp[i + 1, 1] = Math.Max(dp[i, 1], dp[i - 1, 0]) + energyDrinkB[i];
            }

            return Math.Max(dp[len, 0], dp[len, 1]);
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
            long[,] dp = new long[3, 2];
            dp[2, 0] = energyDrinkA[0]; dp[2, 1] = energyDrinkB[0];
            for (int i = 1; i < len; i++)
            {
                dp[0, 0] = dp[1, 0]; dp[1, 0] = dp[2, 0]; dp[0, 1] = dp[1, 1]; dp[1, 1] = dp[2, 1];
                dp[2, 0] = Math.Max(dp[1, 0], dp[0, 1]) + energyDrinkA[i];
                dp[2, 1] = Math.Max(dp[1, 1], dp[0, 0]) + energyDrinkB[i];
            }

            return Math.Max(dp[2, 0], dp[2, 1]);
        }
    }
}
