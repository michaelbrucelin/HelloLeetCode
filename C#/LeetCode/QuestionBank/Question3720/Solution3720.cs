using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3720
{
    public class Solution3720 : Interface3720
    {
        /// <summary>
        /// 贪心
        /// 首先预处理出 s 中每一个字符的频率
        /// 然后从前向后逐位填充，选择与 target[i] 相同的字符
        /// 如果一直填充到最后
        ///     此时字符串与 target 完全相同，找下一个更大的排列即可
        /// 如果没有填充到最后，就找不到与 target[i] 相同的字符了
        ///     此时如果有比 target[i] 更大的字符，取最小的填充，然后余下的字符从小到大填充
        ///     此时如果没有比 target[i] 更大的字符，回到 i-1 位，重新填写 i-1 位，填写更大的字符
        /// </summary>
        /// <param name="s"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public string LexGreaterPermutation(string s, string target)
        {
            int len = s.Length;
            int[] freq = new int[26];
            for (int i = 0; i < len; i++) freq[s[i] - 'a']++;

            char[] result = new char[len];
            int ptr = -1;
            while (++ptr < len)
            {
                if (freq[target[ptr] - 'a'] == 0) break;
                result[ptr] = target[ptr];
                freq[target[ptr] - 'a']--;
            }

            if (ptr == len)
            {
                if (!nextgt(result)) return "";
            }
            else
            {
                int idx;
                while (true)
                {
                    idx = target[ptr] - 'a';
                    while (++idx < 26 && freq[idx] == 0) ;
                    if (idx < 26)
                    {
                        result[ptr] = (char)('a' + idx);
                        freq[idx]--;
                        for (int i = 0; i < 26; i++) for (int j = 0; j < freq[i]; j++) result[++ptr] = (char)('a' + i);
                        break;
                    }
                    else
                    {
                        if (ptr-- == 0) return "";
                        freq[target[ptr] - 'a']++;
                    }
                }
            }

            return new string(result);

            static bool nextgt(char[] chars)
            {
                int len = chars.Length;
                int i = len - 2; while (i >= 0 && chars[i] >= chars[i + 1]) i--;
                if (i < 0) return false;
                int j = len - 1; while (chars[j] <= chars[i]) j--;                  // 这里可以二分，此题数据量不大，直接遍历了
                (chars[i], chars[j]) = (chars[j], chars[i]);
                j = len;
                while ((++i) < (--j)) (chars[i], chars[j]) = (chars[j], chars[i]);
                return true;
            }
        }
    }
}
