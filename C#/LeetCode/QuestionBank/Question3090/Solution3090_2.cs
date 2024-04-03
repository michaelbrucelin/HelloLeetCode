using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3090
{
    public class Solution3090_2 : Interface3090
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaximumLengthSubstring(string s)
        {
            int result = 2, len = s.Length, left = 0, right = -1, id;
            int[] freq = new int[26];
            while (++right < len)
            {
                freq[id = s[right] - 'a']++;
                while (freq[id] > 2) freq[s[left++] - 'a']--;
                result = Math.Max(result, right - left + 1);
            }

            return result;
        }
    }
}
