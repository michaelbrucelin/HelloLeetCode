using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0185
{
    public class Solution0185 : Interface0185
    {
        static Solution0185()
        {
            cache = new double[12][];
            cache[0] = [1D];
            k = 1D / 6;
        }

        private static double[][] cache;
        private static double k;

        /// <summary>
        /// BFS + 记忆化
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public double[] StatisticsProbability(int num)
        {
            if (cache[num] != null) return cache[num];
            int p = 0;
            while (++p <= num)
            {
                if (cache[p] != null) continue;
                cache[p] = new double[p * 5 + 1];
                for (int i = 1, len = (p - 1) * 5 + 1; i < 7; i++) for (int j = 0; j < len; j++)
                    {
                        cache[p][j + i - 1] += cache[p - 1][j] * k;
                    }
            }

            return cache[num];
        }
    }
}
