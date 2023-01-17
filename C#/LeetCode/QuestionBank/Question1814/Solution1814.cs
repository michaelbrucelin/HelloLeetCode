using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1814
{
    public class Solution1814 : Interface1814
    {
        /// <summary>
        /// 数学
        /// x + rev(y) = y + rev(x) <--> x - rev(x) = y - rev(y)
        /// 1. 计算数组中的每一项，nums[i] - rev(nums[i])
        /// 2. 按照结果分组，计算每个结果的数量
        /// 3. 然后每一组求组合值：nC2，即n*(n-1)/2
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountNicePairs(int[] nums)
        {
            const int MOD = 1000000007;
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int val = XMinusRevX(nums[i]);
                if (buffer.ContainsKey(val)) buffer[val]++; else buffer.Add(val, 1);
            }

            int result = 0;
            foreach (int val in buffer.Values)
            {
                if (val < 2) continue;
                result += (int)((((long)val) * (val - 1) >> 1) % MOD);
                result %= MOD;
            }

            return result;
        }

        private int XMinusRevX(int x)
        {
            int rev = 0, t = x;
            while (t > 0)
            {
                var info = Math.DivRem(t, 10);
                rev = rev * 10 + info.Remainder;
                t = info.Quotient;
            }

            return x - rev;
        }
    }
}
