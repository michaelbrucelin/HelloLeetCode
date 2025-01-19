using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2266
{
    public class Solution2266_2 : Interface2266
    {
        static Solution2266_2()
        {
            dp3 = new long[BOR, 3]; dp3[0, 2] = 1;
            dp4 = new long[BOR, 4]; dp4[0, 3] = 1;
            for (int i = 1; i < BOR; i++)
            {
                dp3[i, 0] = (dp3[i - 1, 0] + dp3[i - 1, 1] + dp3[i - 1, 2]) % MOD; dp3[i, 1] = dp3[i - 1, 0]; dp3[i, 2] = dp3[i - 1, 1];
                dp4[i, 0] = (dp4[i - 1, 0] + dp4[i - 1, 1] + dp4[i - 1, 2] + dp4[i - 1, 3]) % MOD; dp4[i, 1] = dp4[i - 1, 0]; dp4[i, 2] = dp4[i - 1, 1]; dp4[i, 3] = dp4[i - 1, 2];
            }
        }

        private const int MOD = (int)1e9 + 7;
        private const int BOR = (int)1e5 + 1;  // 题目限定的范围
        private static long[,] dp3;
        private static long[,] dp4;

        /// <summary>
        /// 逻辑同Solution2266，预处理出DP，空间换时间
        /// </summary>
        /// <param name="pressedKeys"></param>
        /// <returns></returns>
        public int CountTexts(string pressedKeys)
        {
            long result = 1;
            int pl = 0, pr = 0, cnt, len = pressedKeys.Length;
            while (pr < len)
            {
                while (pr + 1 < len && pressedKeys[pr + 1] == pressedKeys[pr]) pr++;
                cnt = pr - pl + 1;
                if (pressedKeys[pl] == '7' || pressedKeys[pl] == '9')
                {
                    result *= dp4[cnt, 0] + dp4[cnt, 1] + dp4[cnt, 2] + dp4[cnt, 3];
                }
                else
                {
                    result *= dp3[cnt, 0] + dp3[cnt, 1] + dp3[cnt, 2];
                }
                result %= MOD;
                pl = ++pr;
            }

            return (int)result;
        }
    }
}
