using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1625
{
    public class Solution1625 : Interface1625
    {
        /// <summary>
        /// 这道题逻辑上没有那么难，但是编码却不是很容易
        /// 枚举
        /// 1. a可以得出有集中“加”的可能
        ///     例如，a=2，有2 4 6 8这4种假的可能，a=5，只有5这一种加的可能
        /// 2. b可以得出哪些位可以作为新字符串的开头，以及只有一半的位可以加a还是所有位都可以加a
        ///     例如，b是偶数的话，就只有奇数位可以加a，b是奇数位的话，所有位都可以加a
        ///     例如s="abcdef", b=3，则只有a与d可以作为字符串的开头
        /// 3. 遍历每一个可以作为开头的可能
        ///     如果b是偶数，就让第一位尽可能小（每次移动两位，a不可能加到偶数位上）
        ///     如果b是奇数，就让前两位尽可能小
        /// 4. 遍历完就找到了最小的新字符串
        /// 
        /// 如果某一位上是i，怎样找出应该加多少？
        ///     如果i=0，不需要加
        ///     如果i>0，依次遍历[10-i, 9]即可，第一个存在的a就是答案，如果一个都不存在，那么不加就是最佳答案
        ///     例如i=6，依次遍历[4, 9]即可
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string FindLexSmallestString(string s, int a, int b)
        {
            int len = s.Length;
            char[] arr_s = s.ToCharArray();
            char[] result = Enumerable.Repeat('9', len).ToArray();

            int[] int_s = new int[len];
            for (int i = 0; i < len; i++) int_s[i] = s[i] & 15;
            bool[] int_a = new bool[10];     // a的所有可能
            for (int i = 1, _a; i <= 9; i++)
            {
                _a = a * i % 10;
                if (_a == 0 || int_a[_a]) break; int_a[_a] = true;
            }
            bool[] int_b = new bool[len]; int_b[0] = true;
            for (int i = len - b; ; i -= b)  // b的所有可能
            {
                if (i < 0) i += len;
                if (int_b[i]) break; int_b[i] = true;
            }

            char[] _buffer = new char[len], _result = new char[len];
            if ((b & 1) != 1)
            {
                for (int i = 0; i < len; i++)
                {
                    if (!int_b[i]) continue;
                    int i1, _a1 = 0;
                    if ((i & 1) != 1) i1 = (i + 1) % len; else i1 = i;
                    for (int j = 10 - int_s[i1]; j < 10; j++) { if (int_a[j]) { _a1 = j; break; } }
                    Array.Copy(arr_s, _buffer, len);
                    if (_a1 != 0) for (int j = 1; j < len; j += 2) _buffer[j] = (char)((((_buffer[j] & 15) + _a1) % 10) | 48);
                    for (int j = 0; j < len; j++) _result[j] = _buffer[(j + i) % len];
                    if (IsSmaller(_result, result)) Array.Copy(_result, result, len);
                }
            }
            else
            {
                for (int i = 0; i < len; i++)
                {
                    if (!int_b[i]) continue;
                    int i0, i1, _a0 = 0, _a1 = 0;
                    if ((i & 1) != 1) { i0 = i; i1 = (i + 1) % len; } else { i0 = (i + 1) % len; i1 = i; }
                    for (int j = 10 - int_s[i0]; j < 10; j++) { if (int_a[j]) { _a0 = j; break; } }
                    for (int j = 10 - int_s[i1]; j < 10; j++) { if (int_a[j]) { _a1 = j; break; } }
                    Array.Copy(arr_s, _buffer, len);
                    if (_a0 != 0) for (int j = 0; j < len; j += 2) _buffer[j] = (char)((((_buffer[j] & 15) + _a0) % 10) | 48);
                    if (_a1 != 0) for (int j = 1; j < len; j += 2) _buffer[j] = (char)((((_buffer[j] & 15) + _a1) % 10) | 48);
                    for (int j = 0; j < len; j++) _result[j] = _buffer[(j + i) % len];
                    if (IsSmaller(_result, result)) Array.Copy(_result, result, len);
                }
            }

            return new string(result);
        }

        private bool IsSmaller(char[] chars1, char[] chars2)
        {
            for (int i = 0; i < chars1.Length; i++)
                if (chars1[i] != chars2[i]) return chars1[i] < chars2[i];
            return false;
        }
    }
}
