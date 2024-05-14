using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3146
{
    public class Solution3146 : Interface3146
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int FindPermutationDifference(string s, string t)
        {
            int result = 0, len = s.Length;
            int[] pos = new int[26];
            for (int i = 0; i < len; i++) pos[s[i] - 'a'] = i;
            for (int i = 0; i < len; i++) result += Math.Abs(pos[t[i] - 'a'] - i);

            return result;
        }
    }
}
