using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3483
{
    public class Solution3483 : Interface3483
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int TotalNumbers(int[] digits)
        {
            int len = digits.Length, num;  // 题目限定长度小于等于10，直接枚举
            HashSet<int> set = [];
            for (int i = 0; i < len; i++) for (int j = i + 1; j < len; j++) for (int k = j + 1; k < len; k++)
                    {
                        num = digits[i] * 100 + digits[j] * 10 + digits[k]; if (num >= 100 && (num & 1) == 0) set.Add(num);
                        num = digits[i] * 100 + digits[k] * 10 + digits[j]; if (num >= 100 && (num & 1) == 0) set.Add(num);
                        num = digits[j] * 100 + digits[i] * 10 + digits[k]; if (num >= 100 && (num & 1) == 0) set.Add(num);
                        num = digits[j] * 100 + digits[k] * 10 + digits[i]; if (num >= 100 && (num & 1) == 0) set.Add(num);
                        num = digits[k] * 100 + digits[i] * 10 + digits[j]; if (num >= 100 && (num & 1) == 0) set.Add(num);
                        num = digits[k] * 100 + digits[j] * 10 + digits[i]; if (num >= 100 && (num & 1) == 0) set.Add(num);
                    }

            return set.Count;
        }
    }
}
