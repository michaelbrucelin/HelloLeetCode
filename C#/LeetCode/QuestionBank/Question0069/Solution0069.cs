using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0069
{
    public class Solution0069 : Interface0069
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt(int x)
        {
            if (x <= 1) return x;

            int result = -1;
            long left = 1, right = x;
            while (left <= right)
            {
                long mid = left + ((right - left) >> 1);
                long pow = mid * mid;
                if (pow == x) return (int)mid;
                if (pow < x)
                {
                    result = (int)mid; left = mid + 1;
                }
                else
                    right = mid - 1;
            }

            return result;
        }
    }
}
