using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2315
{
    public class Solution2315_2 : Interface2315
    {
        public int CountAsterisks(string s)
        {
            return s.Split('|')
                        .Where((i, id) => (id & 1) != 1)      // 题目保证有偶数个 | ，所以可以这样编码
                        .Select(s => s.Count(c => c == '*'))
                        .Sum();
        }
    }
}
