using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0159
{
    public class Solution0159 : Interface0159
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public int[] InventoryManagement(int[] stock, int cnt)
        {
            if (cnt == 0) return [];
            if (cnt == stock.Length) return stock;

            int[] result = new int[cnt];
            Array.Sort(stock);
            Array.Copy(stock, result, cnt);

            return result;
        }
    }
}
