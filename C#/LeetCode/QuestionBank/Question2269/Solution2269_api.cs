using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2269
{
    public class Solution2269_api : Interface2269
    {
        public int DivisorSubstrings(int num, int k)
        {
            int len = num.ToString().Length;
            return Enumerable.Range(0, len - k + 1)
                             .Select(i => int.Parse(num.ToString().Substring(i, k)))
                             .Count(i => i != 0 && num % i == 0);
        }
    }
}
