using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0067
{
    public class Solution0067 : Interface0067
    {
        public string AddBinary(string a, string b)
        {
            if (a.Length < b.Length)
            {
                string t = a; a = b; b = t;  // 让a是比较长的那个
            }

            int len_a = a.Length, len_b = b.Length;
            char[] result = new char[len_a + 1]; result[0] = '0';
            bool extra = false;
            int ptr = 0; for (; ptr < len_b; ptr++)                               // a b共同的部分
            {
                char ca = a[len_a - 1 - ptr], cb = b[len_b - 1 - ptr];
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
            for (; ptr < len_a; ptr++)                                            // a需要进位的部分
            {
                char ca = a[len_a - 1 - ptr];
                if (ca == '1' && extra)
                {
                    result[len_a - ptr] = '0'; extra = true;
                }
                else
                {
                    result[len_a - ptr] = ca == '0' && !extra ? '0' : '1'; extra = false;
                    ptr++; break;
                }
            }
            for (; ptr < len_a; ptr++) result[len_a - ptr] = a[len_a - 1 - ptr];  // a不需要进位的部分
            if (extra) result[0] = '1';

            if (result[0] == '1')
                return new string(result);
            else
                return new string(result, 1, len_a);
        }
    }
}
