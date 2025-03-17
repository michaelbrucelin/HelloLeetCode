using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2272
{
    public class Solution2272 : Interface2272
    {
        /// <summary>
        /// 类前缀和 + 枚举
        /// 大概率会TLE，先写出来试试
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例03
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LargestVariance(string s)
        {
            int result = 0, len = s.Length;
            int[,] freq = new int[len + 1, 26];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < 26; j++) freq[i + 1, j] = freq[i, j];
                freq[i + 1, s[i] - 'a']++;
            }

            int max, min, cnt;
            for (int i = 0; i < len; i++) for (int j = i + 1; j < len; j++)
                {
                    max = 0; min = len;
                    for (int k = 0; k < 26; k++) if ((cnt = freq[j + 1, k] - freq[i, k]) > 0)
                        {
                            max = Math.Max(max, cnt);
                            min = Math.Min(min, cnt);
                        }
                    result = Math.Max(result, max - min);
                }

            return result;
        }
    }
}
