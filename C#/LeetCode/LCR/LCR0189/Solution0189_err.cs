using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0189
{
    public class Solution0189_err : Interface0189
    {
        /// <summary>
        /// 数学
        /// 脑筋急转弯？没弄清楚这道题想要考察什么，不具备乘除，没审好题... ...
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MechanicalAccumulator(int target)
        {
            return target * (target + 1) >> 1;
        }
    }
}
