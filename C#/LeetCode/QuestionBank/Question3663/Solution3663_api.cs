using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3663
{
    public class Solution3663_api : Interface3663
    {
        public int GetLeastFrequentDigit(int n)
        {
            return n.ToString().ToCharArray()
                    .Select(x => x & 15)
                    .GroupBy(x => x)
                    .OrderBy(x => x.Count())
                    .ThenBy(x => x.Key)
                    .First().Key;
        }
    }
}
