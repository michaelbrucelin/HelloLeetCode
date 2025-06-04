using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0161
{
    public class Solution0161 : Interface0161
    {
        /// <summary>
        /// 遍历
        /// 如果累加值<0，重新累加，如果累加值>=0，继续累加
        /// </summary>
        /// <param name="sales"></param>
        /// <returns></returns>
        public int MaxSales(int[] sales)
        {
            int result = sales[0], sum = 0;
            for (int i = 0; i < sales.Length; i++)
            {
                sum += sales[i];
                result = Math.Max(result, sum);
                if (sum < 0) sum = 0;
            }

            return result;
        }
    }
}
