using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2160
{
    public class Solution2160_api : Interface2160
    {
        public int MinimumSum(int num)
        {
            return num.ToString()
                      .Select(c => c & 15)
                      .OrderByDescending(i => i)
                      .Select((i, id) => i * (int)Math.Pow(10, id / 2))
                      .Sum();
        }

        public int MinimumSum2(int num)
        {
            return num.ToString()
                      .OrderByDescending(c => c)
                      .Select((c, id) => (c & 15) * (int)Math.Pow(10, id / 2))
                      .Sum();
        }
    }
}
