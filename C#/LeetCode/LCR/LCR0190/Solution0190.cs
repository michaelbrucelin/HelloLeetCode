using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0190
{
    public class Solution0190 : Interface0190
    {
        /// <summary>
        /// 用位运算模拟加法
        /// </summary>
        /// <param name="dataA"></param>
        /// <param name="dataB"></param>
        /// <returns></returns>
        public int EncryptionCalculate(int dataA, int dataB)
        {
            int carry;
            while (dataB != 0)
            {
                carry = (dataA & dataB) << 1;
                dataA ^= dataB;
                dataB = carry;
            }

            return dataA;
        }
    }
}
