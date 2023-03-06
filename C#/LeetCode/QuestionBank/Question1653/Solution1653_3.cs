using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1653
{
    public class Solution1653_3 : Interface1653
    {
        public int MinimumDeletions(string s)
        {
            int result = 0, cntb = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                    result = Math.Min(result + 1, cntb);
                else
                    cntb++;
            }

            return result;
        }
    }
}
