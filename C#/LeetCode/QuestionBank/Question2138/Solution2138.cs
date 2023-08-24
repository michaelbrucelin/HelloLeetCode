using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2138
{
    public class Solution2138 : Interface2138
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <param name="fill"></param>
        /// <returns></returns>
        public string[] DivideString(string s, int k, char fill)
        {
            int len = s.Length; string[] result;
            (int Quotient, int Remainder) info;
            if ((info = Math.DivRem(len, k)).Remainder != 0)
            {
                result = new string[info.Quotient + 1];
                for (int i = 0; i < result.Length - 1; i++) result[i] = s.Substring(i * k, k);
                result[^1] = $"{s.Substring(info.Quotient * k)}{new string('X', k - info.Remainder).Replace('X', fill)}";
            }
            else
            {
                result = new string[info.Quotient];
                for (int i = 0; i < result.Length; i++) result[i] = s.Substring(i * k, k);
            }

            return result;
        }

        /// <summary>
        /// 与DivideString()一样，只不过换char[]试一下
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <param name="fill"></param>
        /// <returns></returns>
        public string[] DivideString2(string s, int k, char fill)
        {
            int len = s.Length; string[] result;
            (int Quotient, int Remainder) info;
            char[] chars = s.ToCharArray();
            if ((info = Math.DivRem(len, k)).Remainder != 0)
            {
                result = new string[info.Quotient + 1];
                for (int i = 0; i < result.Length - 1; i++) result[i] = new string(chars, i * k, k);
                result[^1] = $"{new string(chars, info.Quotient * k, info.Remainder)}{new string('X', k - info.Remainder).Replace('X', fill)}";
            }
            else
            {
                result = new string[info.Quotient];
                for (int i = 0; i < result.Length; i++) result[i] = s.Substring(i * k, k);
            }

            return result;
        }
    }
}
