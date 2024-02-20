using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0002
{
    public class Solution0002 : Interface0002
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            if (a == "0") return b;
            if (b == "0") return a;

            int len1, len2; string s1, s2;
            if (a.Length >= b.Length)
            {
                len1 = a.Length; len2 = b.Length; s1 = a; s2 = b;
            }
            else
            {
                len1 = b.Length; len2 = a.Length; s1 = b; s2 = a;
            }

            char[] result = new char[len1 + 1];
            char carry = '0'; int cnt, i1, i2;
            for (i1 = len1 - 1, i2 = len2 - 1; i2 >= 0; i1--, i2--)
            {
                cnt = (s1[i1] - '0') + (s2[i2] - '0') + (carry - '0');
                switch (cnt)
                {
                    case 0: result[i1 + 1] = '0'; carry = '0'; break;
                    case 1: result[i1 + 1] = '1'; carry = '0'; break;
                    case 2: result[i1 + 1] = '0'; carry = '1'; break;
                    case 3: result[i1 + 1] = '1'; carry = '1'; break;
                    default: break;
                }
            }
            for (; i1 >= 0; i1--)
            {
                cnt = (s1[i1] - '0') + (carry - '0');
                switch (cnt)
                {
                    case 0: result[i1 + 1] = '0'; carry = '0'; break;
                    case 1: result[i1 + 1] = '1'; carry = '0'; break;
                    case 2: result[i1 + 1] = '0'; carry = '1'; break;
                    default: break;  // case 0: break;
                }
            }
            result[0] = carry;

            if (result[0] != '0') return new string(result); else return new string(result[1..]);
        }

        /// <summary>
        /// 逻辑与AddBinary()完全相同，只是将“加”改为了位运算
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary2(string a, string b)
        {
            if (a == "0") return b;
            if (b == "0") return a;

            int len1, len2; string s1, s2;
            if (a.Length >= b.Length)
            {
                len1 = a.Length; len2 = b.Length; s1 = a; s2 = b;
            }
            else
            {
                len1 = b.Length; len2 = a.Length; s1 = b; s2 = a;
            }

            char[] result = new char[len1 + 1];
            int carry = 0, add, i1, i2;
            for (i1 = len1 - 1, i2 = len2 - 1; i2 >= 0; i1--, i2--)
            {
                add = (s1[i1] - '0') + (s2[i2] - '0') + carry;
                result[i1 + 1] = (char)((add & 1) + '0');
                carry = (add >> 1) & 1;
            }
            for (; i1 >= 0; i1--)
            {
                add = (s1[i1] - '0') + carry;
                result[i1 + 1] = (char)((add & 1) + '0');
                carry = (add >> 1) & 1;
            }
            result[0] = (char)(carry + '0');

            if (result[0] != '0') return new string(result); else return new string(result[1..]);
        }
    }
}
