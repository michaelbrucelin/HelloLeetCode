using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2864
{
    public class Solution2864 : Interface2864
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MaximumOddBinaryNumber(string s)
        {
            int len = s.Length;
            int[] cnt = new int[2];
            for (int i = 0; i < len; i++) cnt[s[i] - '0']++;

            char[] chars = new char[len];
            chars[^1] = '1'; cnt[1]--;
            int id = 0;
            for (int i = 0; i < cnt[1]; i++) chars[id++] = '1';
            for (int i = 0; i < cnt[0]; i++) chars[id++] = '0';

            return new string(chars);
        }
    }
}
