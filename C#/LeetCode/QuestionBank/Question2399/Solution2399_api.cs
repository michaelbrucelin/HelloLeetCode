using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2399
{
    public class Solution2399_api : Interface2399
    {
        public bool CheckDistances(string s, int[] distance)
        {
            return s.Select((c, id) => (c - 'a', id))
                    .GroupBy(t => t.Item1)
                    .All(g => Math.Abs(g.Last().id - g.First().id) - 1 == distance[g.Key]);
        }
    }
}
