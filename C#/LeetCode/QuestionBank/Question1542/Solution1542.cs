using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1542
{
    public class Solution1542 : Interface1542
    {
        /// <summary>
        /// 暴力解
        /// 暴力解试一下，O(10n^2)，大概率会TLE
        /// 1. 字符串中至多有一个字符出现奇数次，那么这个字符串通过交换字符的位置一定可以转化为一个回文串
        /// 2. 类前缀和的方式先预处理[0..n]区间的数字出现的频率，这样稍后可以O(1)计算[m..n]区间的数字频率
        /// 3. 贪心的从大到小逐个字串去查找回文串
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例05
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestAwesome(string s)
        {
            if (s.Length < 2) return 1;

            int len = s.Length;
            int[,] freq = new int[len + 1, 10];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < 10; j++) freq[i + 1, j] = freq[i, j];
                freq[i + 1, s[i] & 15]++;
            }

            int flag;
            for (int window = len; window > 1; window--) for (int left = 0; left <= len - window; left++)
                {
                    flag = 0;
                    for (int i = 0; i < 10; i++) if (((freq[left + window, i] - freq[left, i]) & 1) != 0) flag++;
                    if (flag < 2) return window;
                }

            return 1;
        }

        /// <summary>
        /// 逻辑同LongestAwesome()
        /// 只是将freq简化为int[]，用int表示0-9 10个数字的次数的奇偶性
        ///     1 表示奇数次，0表示偶数次
        /// 时间复杂度可降为LongestAwesome()的1/10，理论上依然TLE
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestAwesome2(string s)
        {
            if (s.Length < 2) return 1;

            int len = s.Length;
            int[] freq = new int[len + 1];
            for (int i = 0; i < len; i++) freq[i + 1] = freq[i] ^ (1 << (s[i] & 15));

            for (int window = len; window > 1; window--) for (int left = 0; left <= len - window; left++)
                {
                    if (BitCount(freq[left + window] ^ freq[left]) < 2) return window;
                }

            return 1;
        }

        private static int BitCount(int u)
        {
            int result = 0;
            while (u > 0) { result++; u &= (u - 1); }

            return result;
        }
    }
}
