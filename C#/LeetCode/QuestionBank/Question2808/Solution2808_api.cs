using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2808
{
    public class Solution2808_api : Interface2808
    {
        public int MinimumSeconds(IList<int> nums)
        {
            int cnt = nums.Count;
            int distance = nums.Select((val, idx) => (val, idx))
                               .GroupBy(t => t.val)
                               .Select(g => (g.Count(), g.Select(t => t.idx).Order().ToArray()))
                               .Select(t => t.Item1 == 1 ?
                                            cnt - 1 :
                                            Math.Max(cnt - t.Item2[^1] + t.Item2[0] - 1,
                                                     Enumerable.Range(1, t.Item1 - 1)
                                                               .Select(i => t.Item2[i] - t.Item2[i - 1] - 1)
                                                               .Max()))
                               .Min();

            return (distance + 1) >> 1;
        }
    }
}
