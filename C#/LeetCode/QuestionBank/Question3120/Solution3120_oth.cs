using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3120
{
    public class Solution3120_oth : Interface3120
    {
        public int NumberOfSpecialChars(string word)
        {
            int[] cnt = new int[2];
            foreach (char c in word) cnt[(c >> 5) & 1] |= 1 << (c & 31);

            return BitCount(cnt[0] & cnt[1]);
        }

        private int BitCount(int u)
        {
            int result = 0;
            while (u > 0) { result++; u &= u - 1; }

            return result;
        }
    }
}
