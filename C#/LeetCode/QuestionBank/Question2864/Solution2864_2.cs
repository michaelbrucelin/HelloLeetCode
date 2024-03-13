using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2864
{
    public class Solution2864_2 : Interface2864
    {
        /// <summary>
        /// “原地”交换
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MaximumOddBinaryNumber(string s)
        {
            char[] chars = s.ToCharArray();
            int pl = 0, pr = chars.Length - 1;
            while (chars[pr] != '1') pr--; chars[pr] = '0'; chars[^1] = '1'; pr--;
            while (pl < pr)
            {
                while (pl < pr && chars[pl] != '0') pl++;
                while (pr > pl && chars[pr] != '1') pr--;
                if (pl < pr)
                {
                    chars[pl++] = '1'; chars[pr--] = '0';
                }
            }

            return new string(chars);
        }
    }
}
