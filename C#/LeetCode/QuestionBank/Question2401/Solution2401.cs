using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2401
{
    public class Solution2401 : Interface2401
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestNiceSubarray(int[] nums)
        {
            int result = 1, len = nums.Length;
            int[] cnts = new int[32];
            int p1 = 0, p2 = -1, num, pos, cnt = 0;
            while (p1 < len - result)
            {
                while (++p2 < len)
                {
                    num = nums[p2]; pos = 0;
                    while (num > 0)
                    {
                        if ((num & 1) == 1) { if (++cnts[pos] == 2) cnt++; }
                        num >>= 1; pos++;
                    }
                    if (cnt > 0) break;
                }
                result = Math.Max(result, p2 - p1);
                if (p2 == len) break;
                while (cnt > 0)
                {
                    num = nums[p1]; pos = 0;
                    while (num > 0)
                    {
                        if ((num & 1) == 1) { if (--cnts[pos] == 1) cnt--; }
                        num >>>= 1; pos++;
                    }
                    p1++;
                }
            }

            return result;
        }
    }
}
