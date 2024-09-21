using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2374
{
    public class Solution2374 : Interface2374
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int EdgeScore(int[] edges)
        {
            int n = edges.Length;
            long[] scores = new long[n];
            for (int i = 0; i < n; i++) scores[edges[i]] += i;

            int result = 0;
            for (int i = 1; i < n; i++) if (scores[i] > scores[result]) result = i;

            return result;
        }
    }
}
