using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0459
{
    public class Solution0459 : Interface0459
    {
        /// <summary>
        /// 暴力解
        /// _len，字串的长度，必须是s长度的约数
        /// 使用多个指针，逐位比较每一个字串对应位上的字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool RepeatedSubstringPattern(string s)
        {
            if (s.Length == 1) return false;

            bool flag = true; int len = s.Length;
            for (int _len = 1; _len <= (len >> 1); _len++, flag = true)
            {
                var info = Math.DivRem(len, _len); if (info.Remainder != 0) continue;
                for (int i = 0; i < _len; i++) for (int j = 1; j < info.Quotient; j++)
                        if (s[_len * j + i] != s[i]) { flag = false; break; }
                if (flag) return true;
            }

            return false;
        }
    }
}
