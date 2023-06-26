using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1897
{
    public class Solution1897 : Interface1897
    {
        /// <summary>
        /// 哈希计数
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public bool MakeEqual(string[] words)
        {
            int len = words.Length;
            int[] freq = new int[26];
            for (int i = 0; i < len; i++) for (int j = 0; j < words[i].Length; j++)
                {
                    freq[words[i][j] - 'a']++;
                }

            for (int i = 0; i < 26; i++) if (freq[i] % len != 0) return false;
            return true;
        }
    }
}
