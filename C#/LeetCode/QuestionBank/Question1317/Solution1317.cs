using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1317
{
    public class Solution1317 : Interface1317
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] GetNoZeroIntegers(int n)
        {
            int[] result = new int[2];
            for (int n1 = 1, n2; n1 < n; n1++)
            {
                n2 = n - n1;
                if (CheckZero(n1) || CheckZero(n2)) continue;
                result[0] = n1; result[1] = n2;
                break;
            }

            return result;
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
