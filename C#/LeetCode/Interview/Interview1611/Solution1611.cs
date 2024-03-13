using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1611
{
    public class Solution1611 : Interface1611
    {
        /// <summary>
        /// 脑筋急转弯
        /// </summary>
        /// <param name="shorter"></param>
        /// <param name="longer"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] DivingBoard(int shorter, int longer, int k)
        {
            if (k == 0) return new int[0];
            if (shorter == longer) return new int[] { shorter * k };

            int[] result = new int[k + 1];  // 0 < shorter <= longer
            int diff = longer - shorter;
            result[0] = shorter * k;
            for (int i = 1; i <= k; i++) result[i] = result[i - 1] + diff;

            return result;
        }
    }
}
