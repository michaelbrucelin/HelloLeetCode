using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1446
{
    public class Solution1446 : Interface1446
    {
        public int MaxPower(string s)
        {
            int result = 1, _r = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1]) _r++;
                else
                {
                    result = Math.Max(result, _r); _r = 1;
                }
            }
            result = Math.Max(result, _r);

            return result;
        }
    }
}
