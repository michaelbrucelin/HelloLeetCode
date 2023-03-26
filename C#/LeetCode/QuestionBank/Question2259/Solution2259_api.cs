using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2259
{
    public class Solution2259_api : Interface2259
    {
        public string RemoveDigit(string number, char digit)
        {
            return number.Select((i, id) => (i, id))
                         .Where(t => t.i == digit)
                         .Select(t => $"{number.Substring(0, t.id)}{number.Substring(t.id + 1)}")
                         .Max();
        }
    }
}
