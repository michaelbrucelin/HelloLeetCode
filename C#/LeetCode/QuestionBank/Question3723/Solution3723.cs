using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3723
{
    public class Solution3723 : Interface3723
    {
        /// <summary>
        /// 贪心
        /// (x+y)^2 - x^2 - y^2 = 2xy >= 0，所有优选选择9 8 7 ...就对了
        /// </summary>
        /// <param name="num"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public string MaxSumOfSquares(int num, int sum)
        {
            (int Q, int R) = Math.DivRem(sum, 9);
            if (Q > num) return "";
            if (Q == num) return R > 0 ? "" : new string('9', num);

            return $"{new string('9', Q)}{R}{new string('0', num - Q - 1)}";
        }
    }
}
