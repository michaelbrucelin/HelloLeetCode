using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0537
{
    public class Solution0537 : Interface0537
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string ComplexNumberMultiply(string num1, string num2)
        {
            int x1, y1, x2, y2;
            (x1, y1) = analyze(num1);
            (x2, y2) = analyze(num2);

            return $"{x1 * x2 - y1 * y2}+{x1 * y2 + x2 * y1}i";

            (int x, int y) analyze(string complex)
            {
                int signx = 1, x = 0, signy = 1, y = 0, p = 0;
                if (complex[p] == '-') { signx = -1; p++; }
                while (complex[p] != '+') x = x * 10 + (complex[p++] & 15);
                p++;
                if (complex[p] == '-') { signy = -1; p++; }
                while (complex[p] != 'i') y = y * 10 + (complex[p++] & 15);

                return (signx * x, signy * y);
            }
        }
    }
}
