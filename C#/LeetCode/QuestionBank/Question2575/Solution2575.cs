using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2575
{
    public class Solution2575 : Interface2575
    {
        /// <summary>
        /// DP
        /// xy%m = p --> xyz%m = (10p+z)%m
        /// </summary>
        /// <param name="word"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int[] DivisibilityArray(string word, int m)
        {
            int len = word.Length;
            int[] result = new int[len];
            long mod = 0;
            for (int i = 0; i < len; i++)
            {
                mod = (mod * 10 + (word[i] & 15)) % m;
                if (mod == 0) result[i] = 1;
            }

            return result;
        }
    }
}
