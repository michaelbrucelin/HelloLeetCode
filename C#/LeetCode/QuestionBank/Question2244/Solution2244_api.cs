using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2244
{
    public class Solution2244_api : Interface2244
    {
        public int MinimumRounds(int[] tasks)
        {
            var freqs = tasks.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            if (freqs.ContainsValue(1)) return -1;
            return freqs.Sum(kv => (kv.Value + 2) / 3);
        }
    }
}
