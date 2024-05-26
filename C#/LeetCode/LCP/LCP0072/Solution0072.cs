using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0072
{
    public class Solution0072 : Interface0072
    {
        /// <summary>
        /// 暴力解，模拟
        /// </summary>
        /// <param name="supplies"></param>
        /// <returns></returns>
        public int[] SupplyWagon(int[] supplies)
        {
            int len = supplies.Length, k = (supplies.Length + 1) >> 1;
            int minid, min, right = len - 1;
            while (k-- > 0)
            {
                minid = right;
                min = supplies[minid] + supplies[minid - 1];
                for (int i = minid - 1; i > 0; i--)
                {
                    if (supplies[i] + supplies[i - 1] <= min)
                    {
                        minid = i;
                        min = supplies[i] + supplies[i - 1];
                    }
                }

                supplies[minid - 1] += supplies[minid];
                for (int i = minid; i < right; i++) supplies[i] = supplies[i + 1];

                right--;
            }

            int[] result = new int[len >> 1];
            for (int i = 0; i < result.Length; i++) result[i] = supplies[i];
            return result;
        }
    }
}
