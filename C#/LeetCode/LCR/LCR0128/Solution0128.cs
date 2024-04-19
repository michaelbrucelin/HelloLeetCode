using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0128
{
    public class Solution0128 : Interface0128
    {
        /// <summary>
        /// 阅读理解
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public int StockManagement(int[] stock)
        {
            return stock.Min();
        }
    }
}
