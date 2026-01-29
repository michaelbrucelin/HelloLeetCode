using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2976
{
    public class Solution2976_2 : Interface2976
    {
        /// <summary>
        /// Floyd
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="original"></param>
        /// <param name="changed"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
        {
            long[,] floyd = new long[26, 26];
            for (int i = 0; i < 26; i++) for (int j = 0; j < 26; j++) floyd[i, j] = int.MaxValue;
            for (int i = 0; i < 26; i++) floyd[i, i] = 0;
            int len = original.Length;
            for (int i = 0; i < len; i++) floyd[original[i] - 'a', changed[i] - 'a'] = Math.Min(floyd[original[i] - 'a', changed[i] - 'a'], cost[i]);
            for (int k = 0; k < 26; k++) for (int i = 0; i < 26; i++) for (int j = 0; j < 26; j++)
                    {
                        if (floyd[i, k] + floyd[k, j] < floyd[i, j]) floyd[i, j] = floyd[i, k] + floyd[k, j];
                    }

            long result = 0; len = source.Length;
            for (int i = 0; i < len; i++)
            {
                if (floyd[source[i] - 'a', target[i] - 'a'] == int.MaxValue) return -1;
                result += floyd[source[i] - 'a', target[i] - 'a'];
            }

            return result;
        }
    }
}
