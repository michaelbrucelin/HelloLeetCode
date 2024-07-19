using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3184
{
    public class Solution3184_api : Interface3184
    {
        public int CountCompleteDayPairs(int[] hours)
        {
            var hs = hours.Select((val, id) => (val, id));
            return hs.SelectMany(x => hs.Select(y => x.id != y.id ? (x.val + y.val) % 24 : 1))
                     .Where(x => x == 0)
                     .Count() >> 1;
        }

        public int CountCompleteDayPairs2(int[] hours)
        {
            var count1 = hours.SelectMany(x => hours.Select(y => (x + y) % 24))
                              .Where(x => x == 0)
                              .Count();
            var count2 = hours.Select(x => (x << 1) % 24)
                              .Where(x => x == 0)
                              .Count();
            return (count1 - count2) >> 1;
        }
    }
}
