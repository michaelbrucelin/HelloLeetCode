using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1781
{
    public class Solution1781 : Interface1781
    {
        /// <summary>
        /// 前缀字典
        /// 例如："aabcb"先生成如下字典
        /// {
        ///     0: {a:1},
        ///     1: {a:2},
        ///     2: {a:2, b:1},
        ///     3: {a:2, b:1, c:1},
        ///     4: {a:2, b:2, c:1}   // 由于字符串中只有小写字母，这里的Value可以使用长度为26的数组代替的
        /// }
        /// 这样就可以迅速计算出任意子字符串的字符频次，对应的“美丽值”也就可以算出来了
        /// 
        /// 滑动窗口
        /// 前缀字典不如滑动窗口快（肉眼可见），直接滑动窗口
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int BeautySum(string s)
        {
            if (s.Length <= 2) return 0;

            int result = 0, len = s.Length;
            int[] freq = new int[26]; freq[s[0] - 'a']++; freq[s[1] - 'a']++;
            for (int l = 3; l <= len; l++)
            {
                freq[s[l - 1] - 'a']++;
                result += BeautyCal(freq);
                int[] freq1 = freq.ToArray();
                for (int i = 1; i <= len - l; i++)
                {
                    freq1[s[i - 1] - 'a']--;
                    freq1[s[i + l - 1] - 'a']++;
                    result += BeautyCal(freq1);
                }
            }

            return result;
        }

        private int BeautyCal(int[] arr)
        {
            int max = 0, min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0) continue;
                if (arr[i] > max) max = arr[i];
                if (arr[i] < min) min = arr[i];
            }

            return max - min;
        }
    }
}
