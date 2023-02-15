using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LeetCode.QuestionBank.Question0441
{
    public class Solution0441 : Interface0441
    {
        /// <summary>
        /// 数学解
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ArrangeCoins(int n)
        {
            long _n = n;
            return (int)Math.Floor(Math.Sqrt((_n << 1) + 0.25D) - 0.5);
        }

        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ArrangeCoins2(int n)
        {
            int result = -1; long low = 1, high = n, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (((mid * (mid + 1)) >> 1) <= n)
                {
                    result = (int)mid; low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return result;
        }

        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ArrangeCoins3(int n)
        {
            int result = 1;
            while (n >= result) n -= result++;

            return result - 1;
        }
    }
}
