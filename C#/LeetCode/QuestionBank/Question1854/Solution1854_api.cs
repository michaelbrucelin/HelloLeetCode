using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1854
{
    public class Solution1854_api : Interface1854
    {
        public int MaximumPopulation(int[][] logs)
        {
            return logs.Select(arr => Enumerable.Range(arr[0], arr[1] - arr[0]))
                       .SelectMany(range => range)
                       .GroupBy(i => i)
                       .OrderByDescending(g => g.Count())
                       .ThenBy(g => g.Key)
                       .First().Key;
        }
    }
}
