using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3210
{
    public class Solution3210 : Interface3210
    {
        /// <summary>
        /// 取模
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string GetEncryptedString(string s, int k)
        {
            // if (k == 0 || s.Length == 0) return s;
            int len = s.Length;
            k %= len;
            if (k == 0) return s;

            return s[k..] + s[0..k];
        }
    }
}
