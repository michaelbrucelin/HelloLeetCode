using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1605
{
    public class Solution1605 : Interface1605
    {
        /// <summary>
        /// 容斥
        /// 1. 每有1个5  的倍数，就会产生1个0
        /// 2. 每有1个25 的倍数，就会多产生1个0
        /// 3. 每有1个125的倍数，就会多产生1个0
        /// 4. 每有1个625的倍数，就会多产生1个0
        /// 5. ... ...
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int TrailingZeroes(int n)
        {
            int result = n / 5, k = 25;
            while (k <= n)
            {
                result += n / k;
                if (k <= 429496729) k *= 5; else break;
            }

            return result;
        }
    }
}
