using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0392
{
    public class Solution0392_5 : Interface0392
    {
        /// <summary>
        /// 进阶
        /// 预处理出t中每1个字符后面第一次出现 a..z 的位置
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubsequence(string s, string t)
        {
            if (s.Length > t.Length) return false;

            int lens = s.Length, lent = t.Length;
            int[,] info = new int[lent + 1, 26];
            for (int i = 0; i <= lent; i++) for (int j = 0; j < 26; j++) info[i, j] = -1;
            for (int i = 0; i < lent; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (info[j, t[i] - 'a'] == -1) info[j, t[i] - 'a'] = i + 1; else break;
                }
            }

            int ps = 0, pt = 0;
            while (ps < lens && (pt = info[pt, s[ps] - 'a']) != -1) ps++;

            return ps == lens;
        }
    }
}
