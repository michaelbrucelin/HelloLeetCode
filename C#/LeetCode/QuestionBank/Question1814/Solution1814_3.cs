using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1814
{
    public class Solution1814_3 : Interface1814
    {
        public int CountNicePairs(int[] nums)
        {
            int result = 0;
            const int MOD = 1000000007;
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int val = XMinusRevX(nums[i]);
                if (buffer.ContainsKey(val))
                {
                    result += buffer[val] % MOD;
                    result %= MOD;
                    buffer[val]++;
                }
                else
                {
                    buffer.Add(val, 1);
                }
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
