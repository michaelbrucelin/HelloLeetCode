using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1017
{
    public class Solution1017_2 : Interface1017
    {
        /// <summary>
        /// 状态机
        /// 逻辑同Solution1017，20240428重写
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string BaseNeg2(int n)
        {
            if (n == 0) return "0";

            List<char> base2 = new List<char>();
            while (n > 0) { base2.Add((char)((n & 1) + '0')); n >>= 1; }
            char carry = '0';
            for (int i = 0; i < base2.Count; i++) switch ((i & 1, base2[i], carry))
                {
                    case (0, '0', '0'): break;
                    case (0, '0', '1'): base2[i] = '1'; carry = '0'; break;
                    case (0, '1', '0'): break;
                    case (0, '1', '1'): base2[i] = '0'; break;
                    case (1, '0', '0'): break;
                    case (1, '0', '1'): base2[i] = '1'; break;
                    case (1, '1', '0'): carry = '1'; break;
                    case (1, '1', '1'): base2[i] = '0'; carry = '1'; break;
                }
            if (carry == '1')
            {
                base2.Add('1'); if ((base2.Count & 1) != 1) base2.Add('1');
            }

            base2.Reverse();
            return new string(base2.ToArray());
        }
    }
}
