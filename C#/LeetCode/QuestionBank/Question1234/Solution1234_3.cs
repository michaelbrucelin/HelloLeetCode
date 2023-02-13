using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1234
{
    public class Solution1234_3 : Interface1234
    {
        public int BalancedString(string s)
        {
            int len = s.Length;
            int[] freq = new int[4];
            for (int i = 0; i < len; i++) freq[(s[i] >> 1) & 3]++;

            int n = len >> 2;
            if (freq.All(i => i == n)) return 0;

            int result = len, left = 0, right = -1;
            while (++right < len)
            {
                freq[(s[right] >> 1) & 3]--;
                while (freq.All(i => i <= n))
                {
                    result = Math.Min(result, right - left + 1);
                    freq[(s[left++] >> 1) & 3]++;
                }
            }

            return result;
        }
    }
}
