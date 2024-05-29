using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0072
{
    internal class Solution0072 : Interface0072
    {
        public int MySqrt(int x)
        {
            long result = -1, low = 0, high = x, mid, pow;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                pow = mid * mid;
                if (pow > x)
                {
                    high = mid - 1;
                }
                else if (pow < x)
                {
                    result = mid; low = mid + 1;
                }
                else  // if(low == mid)
                {
                    return (int)mid;
                }
            }

            return (int)result;
        }

        public int MySqrt2(int x)
        {
            long low = 0, high = x, mid, pow;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                pow = mid * mid;
                if (pow > x)
                {
                    high = mid - 1;
                }
                else if (pow < x)
                {
                    if ((mid + 1) * (mid + 1) > x) return (int)mid;
                    low = mid + 1;
                }
                else  // if(low == mid)
                {
                    return (int)mid;
                }
            }

            throw new Exception("logic error.");
        }
    }
}
