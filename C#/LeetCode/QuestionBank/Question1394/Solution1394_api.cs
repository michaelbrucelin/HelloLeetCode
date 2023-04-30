using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1394
{
    public class Solution1394_api : Interface1394
    {
        public int FindLucky(int[] arr)
        {
            return arr.GroupBy(i => i)
                      .Select(g => (g.Key, g.Count()))
                      .Where(t => t.Key == t.Item2)
                      .DefaultIfEmpty((-1, -1))
                      .Max(t => t.Item1);
        }

        public int FindLucky2(int[] arr)
        {
            return arr.GroupBy(i => i)
                      .Select(g => (g.Key, g.Count()))
                      .Where(t => t.Key == t.Item2)
                      .OrderByDescending(t => t.Key)
                      .DefaultIfEmpty((-1, -1))
                      .First().Item1;
        }
    }
}
