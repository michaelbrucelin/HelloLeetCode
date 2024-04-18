using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0159
{
    public class Solution0159_2 : Interface0159
    {
        /// <summary>
        /// TopK，基于堆
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public int[] InventoryManagement(int[] stock, int cnt)
        {
            if (cnt == 0) return [];
            if (cnt == stock.Length) return stock;

            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            for (int i = 0; i < cnt; i++) maxpq.Enqueue(stock[i], -stock[i]);
            for (int i = cnt; i < stock.Length; i++) if (stock[i] < maxpq.Peek())
                {
                    maxpq.Dequeue(); maxpq.Enqueue(stock[i], -stock[i]);
                }
            int[] result = new int[cnt];
            for (int i = 0; i < cnt; i++) result[i] = maxpq.Dequeue();

            return result;
        }
    }
}
