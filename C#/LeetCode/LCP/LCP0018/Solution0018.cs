using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0018
{
    public class Solution0018 : Interface0018
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="staple"></param>
        /// <param name="drinks"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int BreakfastNumber(int[] staple, int[] drinks, int x)
        {
            Array.Sort(staple);
            Array.Sort(drinks);
            const int MOD = (int)1e9 + 7;
            int result = 0, p1 = 0, p2 = drinks.Length - 1, len = staple.Length;
            while (p1 < len)
            {
                while (p2 >= 0 && staple[p1] + drinks[p2] > x) p2--;
                if (p2 < 0) break;
                result = (result + p2 + 1) % MOD;
                p1++;
            }

            return result;
        }
    }
}
