using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3453
{
    public class Solution3453 : Interface3453
    {
        /// <summary>
        /// 二分
        /// </summary>
        /// <param name="squares"></param>
        /// <returns></returns>
        public double SeparateSquares(int[][] squares)
        {
            double result = double.MinValue, total = 0, bottom, low = double.MaxValue, high = double.MinValue, mid, top;
            foreach (int[] s in squares) { low = Math.Min(low, s[1]); high = Math.Max(high, s[1] + s[2]); total += 1D * s[2] * s[2]; }
            total /= 2;
            const double epsilon = 1e-5;
            while (low <= high)
            {
                mid = low + (high - low) / 2;
                if (high - low < epsilon) return mid;
                bottom = 0;
                foreach (int[] s in squares) if (s[1] < mid)
                    {
                        top = Math.Min(s[1] + s[2], mid);
                        bottom += 1D * (top - s[1]) * s[2];
                    }
                if (bottom - total < 0) low = mid; else high = mid;
            }

            return result;
        }
    }
}
