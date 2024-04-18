using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0159
{
    public class Solution0159_api : Interface0159
    {
        public int[] InventoryManagement(int[] stock, int cnt)
        {
            return stock.OrderBy(x => x).Take(cnt).ToArray();
        }
    }
}
