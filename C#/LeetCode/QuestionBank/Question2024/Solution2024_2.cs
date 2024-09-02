using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2024
{
    public class Solution2024_2 : Interface2024
    {
        /// <summary>
        /// 滑动窗口
        /// 逻辑同Solution2024，只是将预处理的前缀和改为即时计算的形式
        /// </summary>
        /// <param name="answerKey"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxConsecutiveAnswers(string answerKey, int k)
        {
            int result = 0, sumt = 0, sumf = 0, len = answerKey.Length, pl = 0, pr = 0;
            while (pr < len)
            {
                if (answerKey[pr] == 'T') sumt++; else sumf++;
                if (sumt > k && sumf > k)
                {
                    result = Math.Max(result, pr - pl);
                    while (sumt > k && sumf > k)
                    {
                        if (answerKey[pl] == 'T') sumt--; else sumf--;
                        pl++;
                    }
                }
                pr++;
            }
            result = Math.Max(result, pr - pl);

            return result;
        }
    }
}
