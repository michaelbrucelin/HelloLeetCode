using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2024
{
    public class Solution2024 : Interface2024
    {
        /// <summary>
        /// 前缀和 + 双指针
        /// 分别记录T和F的前缀和，一个子串中只要T或者F的数量 <= k，即可
        /// </summary>
        /// <param name="answerKey"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxConsecutiveAnswers(string answerKey, int k)
        {
            int len = answerKey.Length;
            int[] sumt = new int[len + 1], sumf = new int[len + 1];
            for (int i = 0; i < len; i++)
            {
                if (answerKey[i] == 'T')
                {
                    sumt[i + 1] = sumt[i] + 1; sumf[i + 1] = sumf[i];
                }
                else
                {
                    sumt[i + 1] = sumt[i]; sumf[i + 1] = sumf[i] + 1;
                }
            }

            int result = 0, pl = 0, pr = 0;
            while (pr < len)
            {
                if (sumt[pr + 1] - sumt[pl] <= k || sumf[pr + 1] - sumf[pl] <= k)
                {
                    pr++;
                }
                else
                {
                    result = Math.Max(result, pr - pl); pl++;
                }
            }
            result = Math.Max(result, pr - pl);

            return result;
        }
    }
}
