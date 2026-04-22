using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0191
{
    public class Solution0191 : Interface0191
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="arrayA"></param>
        /// <returns></returns>
        public int[] StatisticalResult(int[] arrayA)
        {
            int prod = 1, zerocnt = 0, zeroidx = -1, len = arrayA.Length;
            for (int i = 0; i < len; i++)
            {
                if (arrayA[i] == 0)
                {
                    if (++zerocnt == 1) zeroidx = i; else return new int[len];
                }
                else
                {
                    prod *= arrayA[i];
                }
            }

            int[] result = new int[len];
            if (zerocnt == 0)
            {
                for (int i = 0; i < len; i++) result[i] = prod / arrayA[i];
            }
            else
            {
                result[zeroidx] = prod;
            }

            return result;
        }
    }
}
