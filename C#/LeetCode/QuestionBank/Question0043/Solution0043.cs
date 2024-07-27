using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0043
{
    public class Solution0043 : Interface0043
    {
        /// <summary>
        /// 模拟手算乘法
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") return "0";

            // if (num1.Length < num2.Length) (num1, num2) = (num2, num1);  // 小驱大有意义吗？
            List<int> buffer = new List<int>();
            for (int i = num2.Length - 1, j = 0; i >= 0; i--, j++)
            {
                List<int> _buffer = multi(num1, num2[i] - '0', j);
                add(buffer, _buffer);
            }

            buffer.Reverse();
            char[] result = new char[buffer.Count];
            for (int i = 0; i < buffer.Count; i++) result[i] = (char)('0' + buffer[i]);
            return new string(result);

            List<int> multi(string s, int x, int offset)
            {
                List<int> result = new List<int>();
                for (int i = 0; i < offset; i++) result.Add(0);
                int carry = 0;
                for (int i = s.Length - 1, y, m; i >= 0; i--)
                {
                    y = s[i] & 15;
                    m = y * x + carry;
                    carry = m / 10;
                    result.Add(m % 10);
                }
                if (carry > 0) result.Add(carry);

                return result;
            }

            void add(List<int> x, List<int> y)
            {
                int i, s, carry = 0;
                for (i = 0; i < x.Count && i < y.Count; i++)
                {
                    s = x[i] + y[i] + carry;
                    carry = s / 10;
                    x[i] = s % 10;
                }

                if (i < x.Count)
                {
                    for (; i < x.Count; i++)
                    {
                        s = x[i] + carry;
                        carry = s / 10;
                        x[i] = s % 10;
                    }
                }
                else
                {
                    for (; i < y.Count; i++)
                    {
                        s = y[i] + carry;
                        carry = s / 10;
                        x.Add(s % 10);
                    }
                }
                if (carry > 0) x.Add(carry);
            }
        }
    }
}
