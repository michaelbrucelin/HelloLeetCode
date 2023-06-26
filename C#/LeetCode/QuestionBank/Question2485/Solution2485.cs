using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2485
{
    public class Solution2485 : Interface2485
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int PivotInteger(int n)
        {
            int low = 1, high = n, mid, l, r;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                l = (1 + mid) * mid;
                r = (mid + n) * (n - mid + 1);
                if (l < r) low = mid + 1; else if (l > r) high = mid - 1; else return mid;
            }

            return -1;
        }
    }
}
