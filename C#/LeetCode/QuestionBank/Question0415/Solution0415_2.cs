using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0415
{
    public class Solution0415_2 : Interface0415
    {
        private const long MOD = 1000000000000000000;

        /// <summary>
        /// 将两个字符串从右向左每18位截取一次，然后转为long相加
        /// 
        /// 第k次，截取字符串的(n-18*k， n-18*(k-1)-1)，即(n-18*k, 18)
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string AddStrings(string num1, string num2)
        {
            StringBuilder sb = new StringBuilder();
            long l1, l2, carry = 0; string add;
            int left1 = num1.Length - 18, left2 = num2.Length - 18;
            while (left1 > -18 && left2 > -18)
            {
                l1 = long.Parse(left1 >= 0 ? num1.Substring(left1, 18) : num1.Substring(0, left1 + 18));
                l2 = long.Parse(left2 >= 0 ? num2.Substring(left2, 18) : num2.Substring(0, left2 + 18));
                add = ((l1 + l2 + carry) % MOD).ToString(); sb.Insert(0, add);
                if (add.Length < 18) sb.Insert(0, new string('0', 18 - add.Length));
                carry = (l1 + l2 + carry) / MOD;
                left1 -= 18; left2 -= 18;
            }
            if (left2 > -18) { num1 = num2; left1 = left2; }
            while (left1 > -18)
            {
                l1 = long.Parse(left1 >= 0 ? num1.Substring(left1, 18) : num1.Substring(0, left1 + 18));
                add = ((l1 + carry) % MOD).ToString(); sb.Insert(0, add);
                if (add.Length < 18) sb.Insert(0, new string('0', 18 - add.Length));
                carry = (l1 + carry) / MOD;
                left1 -= 18;
            }

            string result = sb.ToString();
            if (carry > 0)
                return $"{carry}{result}";
            else
            {
                result = result.TrimStart('0');
                return result == "" ? "0" : result;
            }
        }
    }
}
