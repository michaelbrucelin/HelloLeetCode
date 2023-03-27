using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2496
{
    public class Solution2496_api : Interface2496
    {
        public int MaximumValue(string[] strs)
        {
            return strs.Max(s => s.All(c => char.IsDigit(c)) ? int.Parse(s) : s.Length);
        }

        public int MaximumValue2(string[] strs)
        {
            int _r;
            return strs.Max(s => int.TryParse(s, out _r) ? _r : s.Length);
        }
    }
}
