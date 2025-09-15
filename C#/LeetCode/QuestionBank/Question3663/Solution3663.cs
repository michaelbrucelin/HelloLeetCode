using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3663
{
    public class Solution3663 : Interface3663
    {
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GetLeastFrequentDigit(int n)
        {
            int[] freq = new int[11];
            freq[10] = 100;
            while (n > 0)
            {
                freq[n % 10]++; n /= 10;
            }

            int result = 10;
            for (int i = 9; i >= 0; i--)
            {
                if (freq[i] > 0 && freq[i] <= freq[result]) result = i;
            }

            return result;
        }
    }
}
