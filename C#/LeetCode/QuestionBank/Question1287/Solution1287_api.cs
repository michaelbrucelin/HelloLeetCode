using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1287
{
    public class Solution1287_api : Interface1287
    {
        public int FindSpecialInteger(int[] arr)
        {
            return arr.GroupBy(i => i)
                      .ToDictionary(g => g.Key, g => g.Count())
                      .OrderByDescending(kv => kv.Value)
                      .First().Key;
        }
    }
}
