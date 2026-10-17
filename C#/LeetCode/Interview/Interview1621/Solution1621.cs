using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1621
{
    public class Solution1621 : Interface1621
    {
        /// <summary>
        /// 数学 + Hash
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public int[] FindSwapValues(int[] array1, int[] array2)
        {
            int sum1 = 0, sum2 = 0;
            HashSet<int> set2 = [];
            foreach (int x in array1) sum1 += x;
            foreach (int x in array2) { sum2 += x; set2.Add(x); }

            int diff = sum1 - sum2;
            if ((diff & 1) != 0) return [];
            diff >>= 1;
            foreach (int x in array1) if (set2.Contains(x - diff)) return [x, x - diff];

            return [];
        }
    }
}
