using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0159
{
    public class Solution0159_4 : Interface0159
    {
        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public int[] InventoryManagement(int[] stock, int cnt)
        {
            if (cnt == 0) return [];
            if (cnt == stock.Length) return stock;

            int[] freq = new int[10001];
            for (int i = 0; i < stock.Length; i++) freq[stock[i]]++;

            int[] result = new int[cnt];
            for (int i = 0, j = 0; i < cnt; i++)
            {
                while (freq[j] == 0) j++;
                result[i] = j;
                freq[j]--;
            }

            return result;
        }
    }
}
