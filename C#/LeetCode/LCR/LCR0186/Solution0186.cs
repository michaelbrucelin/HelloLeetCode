using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0186
{
    public class Solution0186 : Interface0186
    {
        public bool CheckDynasty(int[] places)
        {
            int max = 0, min = 14;
            HashSet<int> visited = new HashSet<int>();
            foreach (int i in places) if (i != 0)
                {
                    if (visited.Contains(i)) return false;
                    visited.Add(i);
                    max = Math.Max(max, i); min = Math.Min(min, i);
                }

            return max - min <= 4;
        }
    }
}
