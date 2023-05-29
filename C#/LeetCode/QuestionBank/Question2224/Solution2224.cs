using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2224
{
    public class Solution2224 : Interface2224
    {
        private static readonly int[] spans = new int[] { 60, 15, 5, 1 };

        /// <summary>
        /// 先求出分钟差，然后从大到小取尝试
        /// </summary>
        /// <param name="current"></param>
        /// <param name="correct"></param>
        /// <returns></returns>
        public int ConvertTime2(string current, string correct)
        {
            int result = 0, diff = 0, hh1, hh2, mi1, mi2;
            hh1 = int.Parse(current[0..2]); mi1 = int.Parse(current[3..]);
            hh2 = int.Parse(correct[0..2]); mi2 = int.Parse(correct[3..]);
            if (hh1 == hh2)
            {
                diff = mi2 - mi1;
            }
            else  // if(hh1 < hh2)
            {
                if (hh2 - hh1 > 1) result += hh2 - hh1 - 1;
                diff += 60 - mi1 + mi2;
            }
            for (int i = 0, span; i < 4; i++)
            {
                span = spans[i];
                result += diff / span; diff = diff % span;
            }

            return result;
        }

        /// <summary>
        /// 与ConvertTime()一样，使用API计算分钟差
        /// </summary>
        /// <param name="current"></param>
        /// <param name="correct"></param>
        /// <returns></returns>
        public int ConvertTime(string current, string correct)
        {
            DateTime time1 = Convert.ToDateTime($"1900-01-01 {current}:00");
            DateTime time2 = Convert.ToDateTime($"1900-01-01 {correct}:00");
            int diff = (int)(time2 - time1).TotalMinutes;

            int result = 0;
            for (int i = 0, span; i < 4; i++)
            {
                span = spans[i];
                result += diff / span; diff = diff % span;
            }

            return result;
        }
    }
}
