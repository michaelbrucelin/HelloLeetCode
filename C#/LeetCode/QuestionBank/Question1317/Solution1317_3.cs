using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1317
{
    public class Solution1317_3 : Interface1317
    {
        /// <summary>
        /// 无限猴子
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] GetNoZeroIntegers(int n)
        {
            Random random = new Random();
            int n1, n2;
            while (true)
            {
                n1 = random.Next(1, n); n2 = n - n1;
                if (CheckZero(n1) || CheckZero(n2)) continue;
                break;
            }

            return [n1, n2];
        }

        private bool CheckZero(int n)
        {
            while (n > 0)
            {
                if (n % 10 == 0) return true;
                n /= 10;
            }
            return false;
        }
    }
}
