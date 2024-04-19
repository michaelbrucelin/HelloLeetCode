using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0158
{
    public class Solution0158 : Interface0158
    {
        /// <summary>
        /// 摩尔投票
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public int InventoryManagement(int[] stock)
        {
            int result = 0, cnt = 0, len = stock.Length;
            for (int i = 0, val; i < len; i++)
            {
                val = stock[i];
                if (cnt == 0)
                {
                    result = val; cnt = 1;
                }
                else
                {
                    if (val == result) cnt++; else cnt--;
                }
            }

            return result;
        }
    }
}
