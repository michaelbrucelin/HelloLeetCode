
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0166
{
    public class Solution0166 : Interface0166
    {
        /// <summary>
        /// 找规律，编程的思想，有数学解
        /// 题目限定答案字符串的长度小于10^4，所以最多循环10^4次后就可以找出结果
        /// 1. 找出numerator与denominator的gcd，化为最简分数x/y
        /// 2. 不断的计算，x%y, x*10%y, x*100%y, ...
        ///     当结果出现0，即可以表示为有限小数
        ///     当结果出现重复，即找到了循环节的长度以及具体的循环节
        /// 
        /// 例如：1/200     0.005
        /// 1%200           1
        /// 10%200          10
        /// 100%200         100
        /// 1000%200        0      出现0
        /// 
        /// 1000/200        5
        /// 1000/1=1000，有3个0，所以结果需要小数点向前移3位，0.005
        /// 
        /// 例如：7/24000   0.000291(6)
        /// 7%24000         7
        /// 70%24000        70
        /// 700%24000       700
        /// 7000%24000      7000
        /// 70000%24000     22000
        /// 700000%24000    4000
        /// 7000000%24000   16000
        /// 70000000%24000  16000  出现重复
        /// 
        /// 70000000/24000  2916
        /// 70000000/7=10000000，有7个0，所以结果需要小数点向前移7位，0.0002916
        /// 70000000/7000000=10，有1个0，所以循环节长度位1，即结果为：0.000291(6)
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
            long gcd = GetGCD(_numerator, _denominator);
            BigInteger x = _numerator / gcd, y = _denominator / gcd, _x = x, r;
            Dictionary<int, int> remainder = new Dictionary<int, int>();
            int id = 0;
            while (true)
            {
                r = _x % y;
                if (r == 0 || remainder.ContainsKey((int)r)) break;
                remainder.Add((int)r, id++);
                _x *= 10;
            }

            string result = (_x / y).ToString();
            int dotpos = result.Length - id;
            result = dotpos > 0 ? $"{result[..dotpos]}.{result[dotpos..]}" : $"0.{new string('0', -dotpos)}{result}";
            if (r != 0)
            {
                int len = result.Length, _len = id - remainder[(int)r];
                result = $"{result[..(len - _len)]}({result[(len - _len)..]})";
            }

            return sign == -1 ? $"-{result}" : result;

            long GetGCD(long x, long y)
            {
                if (x == y) return x;

                int move = 0;
                while (x != y) switch ((x & 1, y & 1))
                    {
                        case (0, 0): x >>= 1; y >>= 1; move++; break;
                        case (0, 1): x >>= 1; break;
                        case (1, 0): y >>= 1; break;
                        default:  // (1, 1)
                            if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                            break;
                    }

                return x << move;
            }
        }

        /// <summary>
        /// 逻辑同FractionToDecimal()，删除了分数约分的步骤，没有用，画蛇添足了
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <returns></returns>
        public string FractionToDecimal2(int numerator, int denominator)
        {
            long _numerator = numerator, _denominator = denominator;
            if (_numerator % _denominator == 0) return (_numerator / _denominator).ToString();  // 溢出... ...

            int sign = 1;
            if (_numerator < 0) { sign *= -1; _numerator *= -1; }
            if (_denominator < 0) { sign *= -1; _denominator *= -1; }
            BigInteger x = _numerator, y = _denominator, _x = x, r;
            Dictionary<int, int> remainder = new Dictionary<int, int>();
            int id = 0;
            while (true)
            {
                r = _x % y;
                if (r == 0 || remainder.ContainsKey((int)r)) break;
                remainder.Add((int)r, id++);
                _x *= 10;
            }

            string result = (_x / y).ToString();
            int dotpos = result.Length - id;
            result = dotpos > 0 ? $"{result[..dotpos]}.{result[dotpos..]}" : $"0.{new string('0', -dotpos)}{result}";
            if (r != 0)
            {
                int len = result.Length, _len = id - remainder[(int)r];
                result = $"{result[..(len - _len)]}({result[(len - _len)..]})";
            }

            return sign == -1 ? $"-{result}" : result;
        }
    }
}
