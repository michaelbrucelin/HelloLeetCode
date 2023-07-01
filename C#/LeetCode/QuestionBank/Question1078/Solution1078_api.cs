using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1078
{
    public class Solution1078_api : Interface1078
    {
        public string[] FindOcurrences(string text, string first, string second)
        {
            var strs = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return strs.Skip(2)
                       .Select((str, id) => (str, id)).Where(t => strs[t.id] == first && strs[t.id + 1] == second)
                       .Select(t => t.str)
                       .ToArray();
        }
    }
}
