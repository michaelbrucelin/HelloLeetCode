using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2559
{
    public class Solution2559_api : Interface2559
    {
        private static readonly HashSet<char> vowel = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };

        public int[] VowelStrings(string[] words, int[][] queries)
        {
            var query = Enumerable.Range(0, 1);
            query = query.Concat(words.Select(w => vowel.Contains(w[0]) && vowel.Contains(w[^1]) ? 1 : 0));
            int sum = 0;
            int[] pre = query.Select(i => sum += i).ToArray();

            return queries.Select(arr => pre[arr[1] + 1] - pre[arr[0]]).ToArray();
        }
    }
}
