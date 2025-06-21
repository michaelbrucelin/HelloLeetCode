using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3085
{
    public class Solution3085 : Interface3085
    {
        /// <summary>
        /// 分析
        /// 频次少的字母要么不删除，要么全部删除，频次多的字符每次删除需要删除到最小频次+k为止
        /// </summary>
        /// <param name="word"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumDeletions(string word, int k)
        {
            int[] freq = new int[26];
            foreach (char c in word) freq[c - 'a']++;
            Array.Sort(freq);
            int[] psum = new int[27];
            for (int i = 0; i < 26; i++) psum[i + 1] = psum[i] + freq[i];

            int result = word.Length, _result, pl = -1, pr = 0;
            while (++pl < 26)
            {
                while (pr + 1 < 26 && freq[pr + 1] <= freq[pl] + k) pr++;
                if (pr < 26)
                {
                    _result = psum[pl] + (psum[26] - psum[pr + 1] - (freq[pl] + k) * (25 - pr));
                }
                else
                {
                    _result = psum[pl];
                }
                result = Math.Min(result, _result);
                if (pr == 26) break;
            }

            return result;
        }
    }
}
