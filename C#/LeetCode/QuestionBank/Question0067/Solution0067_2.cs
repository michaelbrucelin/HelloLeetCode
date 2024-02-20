using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0067
{
    public class Solution0067_2 : Interface0067
    {
        /// <summary>
        /// 模拟
        /// 与Solution0067一样，不过将两个字符串长度补齐，与Solution0067相比，代码更简单，执行略慢
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            if (a.Length < b.Length)
            {
                string t = a; a = b; b = t;  // 让a是比较长的那个
            }

            int len_a = a.Length, len_b = b.Length;
            if (len_a > len_b) b = $"{new string('0', len_a - len_b)}{b}";
            char[] result = new char[len_a + 1]; result[0] = '0';
            bool extra = false;
            int ptr = 0; for (; ptr < len_a; ptr++)
            {
                char ca = a[len_a - 1 - ptr], cb = b[len_a - 1 - ptr];
                if (ca == '0' && cb == '0')
                {
                    result[len_a - ptr] = extra ? '1' : '0'; extra = false;
                }
                else if (ca == '1' && cb == '1')
                {
                    result[len_a - ptr] = extra ? '1' : '0'; extra = true;
                }
                else
                {
                    if (extra)
                    {
                        result[len_a - ptr] = '0'; extra = true;
                    }
                    else
                    {
                        result[len_a - ptr] = '1'; extra = false;
                    }
                }
            }
            if (extra) result[0] = '1';

            if (result[0] == '1')
                return new string(result);
            else
                return new string(result, 1, len_a);
        }
    }
}
