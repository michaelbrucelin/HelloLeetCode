using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1047
{
    public class Solution1047_3 : Interface1047
    {
        /// <summary>
        /// 字符串替换
        /// 提交会超时，参考测试用例04
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveDuplicates(string s)
        {
            string[] ss = new string[26];
            for (int i = 0; i < 26; i++) ss[i] = $"{(char)('a' + i)}{(char)('a' + i)}";

            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < 26; i++) if (s.Contains(ss[i]))
                    {
                        s = s.Replace(ss[i], ""); flag = true;
                    }
            }

            return s;
        }

        /// <summary>
        /// 正则替换
        /// 实测比上面的字符串替换更慢
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveDuplicates2(string s)
        {
            while (Regex.IsMatch(s, @"([a-z])\1{1}"))
                s = Regex.Replace(s, @"([a-z])\1{1}", "");

            return s;
        }
    }
}
