using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2544
{
    public class Solution2544_api : Interface2544
    {
        public int AlternateDigitSum(int n)
        {
            return n.ToString().Select((c, id) => (c - '0') * (int)Math.Pow(-1, id)).Sum();
        }
    }
}
