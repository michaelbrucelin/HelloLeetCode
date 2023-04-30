using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0367
{
    public class Solution0367 : Interface0367
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsPerfectSquare(int num)
        {
            long low = 0, high = num, mid, pow;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                pow = mid * mid;
                if (pow == num)
                    return true;
                else if (pow < num)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return false;
        }
    }
}
