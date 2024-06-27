using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0476
{
    public class Solution0476 : Interface0476
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int FindComplement(int num)
        {
            if (num == 0) return 1;

            int result = 0, pow = 1;
            while (num > 0)
            {
                result += (1 - (num & 1)) * pow;
                num >>= 1; pow <<= 1;
            }

            return result;
        }

        public int FindComplement2(int num)
        {
            int result = 0;
            for (int i = 0; num > 0; i++)
            {
                result |= ((num & 1) ^ 1) << i;
                num >>= 1;
            }

            return result;
        }
    }
}
