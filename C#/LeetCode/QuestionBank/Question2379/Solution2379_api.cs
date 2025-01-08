using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2379
{
    public class Solution2379_api : Interface2379
    {
        public int MinimumRecolors(string blocks, int k)
        {
            return Enumerable.Range(0, blocks.Length - k + 1)
                             .Select(i => blocks.Skip(i).Take(k).Count(c => c != 'B'))
                             .Min();
        }

        public int MinimumRecolors2(string blocks, int k)
        {
            return Enumerable.Range(0, blocks.Length - k + 1)
                             .Select(i => blocks.Skip(i).Take(k).Sum(c => c & 1))
                             .Min();
        }
    }
}
