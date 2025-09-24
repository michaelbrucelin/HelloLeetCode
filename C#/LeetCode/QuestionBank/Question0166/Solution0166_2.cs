using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0166
{
    public class Solution0166_2 : Interface0166
    {
        /// <summary>
        /// 找规律
        /// 逻辑同Solution0166，这里不再借助BigInteger，而是使用长除法
        /// 具体解释见官解
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <returns></returns>
        public string FractionToDecimal(int numerator, int denominator)
        {
            long _numerator = numerator, _denominator = denominator;
            if (_numerator % _denominator == 0) return (_numerator / _denominator).ToString();  // 溢出... ...

            int sign = 1;
            if (_numerator < 0) { sign *= -1; _numerator *= -1; }
            if (_denominator < 0) { sign *= -1; _denominator *= -1; }
            long x = _numerator, y = _denominator;
            StringBuilder sb = new StringBuilder();
            if (sign != 1) sb.Append("-");
            sb.Append(x > y ? $"{x / y}." : "0.");
            x %= y;
            Dictionary<long, int> remainder = new Dictionary<long, int>();
            int id = 0;
            while (x != 0 && !remainder.ContainsKey(x))
            {
                remainder.Add(x, id++);
                x *= 10;
                sb.Append($"{x / y}");
                x %= y;
            }

            string result = sb.ToString();
            if (x != 0)
            {
                int len = result.Length, _len = id - remainder[x];
                result = $"{result[..(len - _len)]}({result[(len - _len)..]})";
            }

            return result;
        }
    }
}
