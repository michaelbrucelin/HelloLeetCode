using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2266
{
    public class Solution2266_3 : Interface2266
    {
        static Solution2266_3()
        {
            dp3 = new long[BOR]; dp3[0] = dp3[1] = 1; dp3[2] = 2; dp3[3] = 4;
            dp4 = new long[BOR]; dp4[0] = dp4[1] = 1; dp4[2] = 2; dp4[3] = 4;
            for (int i = 4; i < BOR; i++)
            {
                dp3[i] = (dp3[i - 1] + dp3[i - 2] + dp3[i - 3]) % MOD;
                dp4[i] = (dp4[i - 1] + dp4[i - 2] + dp4[i - 3] + dp4[i - 4]) % MOD;
            }
        }

        private const int MOD = (int)1e9 + 7;
        private const int BOR = (int)1e5 + 1;  // 题目限定的范围
        private static long[] dp3;
        private static long[] dp4;

        /// <summary>
        /// 逻辑同Solution2266_2，预处理出DP，空间换时间
        /// 但是，DP的过程中不需要记录每个位置结尾是按1下，按2下...的次数，最后如果按2下，就直接找位置-2即可
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
                if (pressedKeys[pl] == '7' || pressedKeys[pl] == '9') result *= dp4[cnt]; else result *= dp3[cnt];
                result %= MOD;
                pl = ++pr;
            }

            return (int)result;
        }
    }
}
