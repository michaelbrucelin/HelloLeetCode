using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3734
{
    public class Solution3734 : Interface3734
    {
        /// <summary>
        /// 分类讨论 + 贪心
        /// 1. 预处理出 s 中字符的频率，判断是否可以构成回文排列
        /// 2. 采用与Solution3720相同的策略，但是只处理前一半（len/2）排列
        ///     如果前一半与 target 的前一半完全相等，则判断后一半是否大于 target 的后一半
        ///         如果后一半大于 target 的后一半，则这就是结果
        ///         如果后一半小于等于 target 的后一半，则找出前一半的下一个更大的排列，即使结果
        ///     如果前一半与 target 的前一半不等，无论是大还是小，都已经是结果了
        /// 
        /// 没写完，不写了，不难，但是恶心
        /// </summary>
        /// <param name="s"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public string LexPalindromicPermutation(string s, string target)
        {
            int len = s.Length;
            int[] freq = new int[26];
            for (int i = 0; i < len; i++) freq[s[i] - 'a']++;
            char mid = '\0';
            for (int i = 0; i < 26; i++)
            {
                if ((freq[i] & 1) != 0)
                {
                    if ((len & 1) == 0 || mid != '\0') return "";
                    mid = (char)('a' + i);
                }
                freq[i] >>= 1;
            }

            char[] result = new char[len];
            int ptr = -1, idx, half = len >> 1;
            while (++ptr < half)
            {
                if (freq[idx = target[ptr] - 'a'] == 0) break;
                result[ptr] = target[ptr];
                freq[idx]--;
            }

            if (ptr == half)
            {
                if (mid != '\0')
                {
                    
                }
            }
            else
            {
            }

            return new string(result);
        }
    }
}
