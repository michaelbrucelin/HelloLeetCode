using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2266
{
    public class Solution2266 : Interface2266
    {
        /// <summary>
        /// 排列组合 + DP
        /// 不同的数字之间可能性相乘
        /// 相同的数字，DP计算可能性
        ///     如果是2 3 4 5 6 8，分别记录结尾是F(N,1)=按1次，F(N,2)=按2次，F(N,3)=按3次的可能的数量
        ///     多按一次，F(N+1,1)=F(N,1)+F(N,2)+F(N,1)，F(N+1,2)=F(N,2)，F(N+1,3)=F(N,2)
        ///     如果是7 9，多记录F(N,4)=按4次的数量
        /// </summary>
        /// <param name="pressedKeys"></param>
        /// <returns></returns>
        public int CountTexts(string pressedKeys)
        {
            const int MOD = (int)1e9 + 7;
            List<long[]> dp3 = new List<long[]>() { new long[] { 0, 0, 1 } };
            List<long[]> dp4 = new List<long[]>() { new long[] { 0, 0, 0, 1 } };

            long result = 1;
            int pl = 0, pr = 0, cnt, len = pressedKeys.Length;
            while (pr < len)
            {
                while (pr + 1 < len && pressedKeys[pr + 1] == pressedKeys[pr]) pr++;
                cnt = pr - pl + 1;
                if (pressedKeys[pl] == '7' || pressedKeys[pl] == '9')
                {
                    while (dp4.Count <= cnt) dp4.Add([(dp4[^1][0] + dp4[^1][1] + dp4[^1][2] + dp4[^1][3]) % MOD, dp4[^1][0], dp4[^1][1], dp4[^1][2]]);
                    result *= dp4[cnt][0] + dp4[cnt][1] + dp4[cnt][2] + dp4[cnt][3];
                }
                else
                {
                    while (dp3.Count <= cnt) dp3.Add([(dp3[^1][0] + dp3[^1][1] + dp3[^1][2]) % MOD, dp3[^1][0], dp3[^1][1]]);
                    result *= dp3[cnt][0] + dp3[cnt][1] + dp3[cnt][2];
                }
                result %= MOD;
                pl = ++pr;
            }

            return (int)result;
        }
    }
}
