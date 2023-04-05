using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0594
{
    public class Solution0594_api : Interface0594
    {
        public int FindLHS(int[] nums)
        {
            var dic = nums.GroupBy(i => i).ToImmutableSortedDictionary(g => g.Key, g => g.Count());
            return dic.Skip(1)
                      .Zip(dic, (kv1, kv2) => kv1.Key == kv2.Key + 1 ? kv1.Value + kv2.Value : 0)
                      .DefaultIfEmpty(0)
                      .Max();
        }
    }
}
