using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3813
{
    public class Solution3813 : Interface3813
    {
        private static readonly byte[] vowels = [1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0];

        public int VowelConsonantScore(string s)
        {
            int[] cnts = new int[2];
            foreach (char c in s) if (char.IsAsciiLetterLower(c)) cnts[vowels[c - 'a']]++;

            return cnts[0] == 0 ? 0 : (int)Math.Floor(1D * cnts[1] / cnts[0]);
        }
    }
}
