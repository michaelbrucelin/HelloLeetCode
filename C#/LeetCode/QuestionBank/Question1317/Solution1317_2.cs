using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1317
{
    public class Solution1317_2 : Interface1317
    {
        /// <summary>
        /// 策略
        /// 从低位到高位，逐位分解，分析这一位的值
        ///     -1  向高位借1  拆分为 1,8    -1是由于被低位借1产生的
        ///      0  向高位借1  拆分为 1,9
        ///      1  向高位借1  拆分为 2,9
        ///     >1             拆分为 1,x
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] GetNoZeroIntegers(int n)
        {
            int n1 = 0, n2 = 0, pos = 1, k, carry = 0;
            while (n > 0)
            {
                k = n % 10 - carry; n /= 10;
                switch (k)
                {
                    case -1:  // 此时n一定大于0
                        carry = 1; n1 += pos; n2 += 8 * pos;
                        break;
                    case 0:
                        if (n > 0)
                        {
                            carry = 1; n1 += pos; n2 += 9 * pos;
                        }
                        break;
                    case 1:
                        if (n > 0)
                        {
                            carry = 1; n1 += 2 * pos; n2 += 9 * pos;
                        }
                        else
                        {
                            carry = 0; n2 += pos;
                        }
                        break;
                    default:
                        carry = 0; n1 += pos; n2 += (k - 1) * pos;
                        break;
                }
                pos *= 10;
            }

            return [n1, n2];
        }
    }
}
