using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3211
{
    public class Solution3211_off_2 : Interface3211
    {
        public IList<string> ValidStrings(int n)
        {
            List<string> result = new List<string>();
            int mask = (1 << n) - 1;
            for (int i = 0, j; i <= mask; i++)
            {
                j = i ^ mask;
                if ((j & (j >> 1)) == 0)
                {
                    string _s = Convert.ToString(i, 2);
                    result.Add(_s.Length == n ? _s : $"0{_s}");
                }
            }

            return result;
        }
    }
}
