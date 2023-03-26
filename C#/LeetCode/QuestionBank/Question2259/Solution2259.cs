using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2259
{
    public class Solution2259 : Interface2259
    {
        /// <summary>
        /// 暴力解
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public string RemoveDigit(string number, char digit)
        {
            int len = number.Length;
            string result = new string('0', len - 1), _result;
            for (int i = 0; i < len; i++)
            {
                if (number[i] == digit)
                {
                    _result = $"{number.Substring(0, i)}{number.Substring(i + 1)}";
                    if (string.CompareOrdinal(_result, result) > 0) result = _result;
                }
            }

            return result;
        }
    }
}
