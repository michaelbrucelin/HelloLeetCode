using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1177
{
    public class Solution1177 : Interface1177
    {
        /// <summary>
        /// 前缀和
        /// 1. 可以回文的充要条件是字符串中至多有一个字符的数量是奇数
        /// 2. 每次字符替换可以消灭掉两个数量为奇数的字符
        /// 3. 如果字符替换的次数达到字符串长度的一半，结果一定为true
        /// 4. 长度是1的字符串一定是回文
        /// 基于上面几条结论，所以只要快速得出子串中有多少个数量为奇数的字符即可，这个可以预处理出类似于“前缀和”的结果就可以
        /// 这里预处理的结果使用二维数组来存储
        /// </summary>
        /// <param name="s"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public IList<bool> CanMakePaliQueries(string s, int[][] queries)
        {
            int len_s = s.Length, len_q = queries.Length;
            bool[,] pre = new bool[26, len_s + 1];  // false: 偶数, true: 奇数
            for (int i = 0, id; i < len_s; i++)
            {
                id = s[i] - 'a';
                for (int j = 0; j < id; j++) pre[j, i + 1] = pre[j, i];
                pre[id, i + 1] = !pre[id, i];
                for (int j = id + 1; j < 26; j++) pre[j, i + 1] = pre[j, i];
            }

            bool[] result = new bool[len_q];
            int left, right, k, odd;
            for (int i = 0; i < len_q; i++)
            {
                left = queries[i][0]; right = queries[i][1]; k = queries[i][2];
                if (left == right || k >= ((right - left + 1) >> 1))
                {
                    result[i] = true;
                }
                else
                {
                    odd = 0;
                    for (int j = 0; j < 26; j++) if (pre[j, right + 1] != pre[j, left]) odd++;
                    if (k >= (odd >> 1)) result[i] = true;
                }
            }

            return result;
        }

        /// <summary>
        /// 与CanMakePaliQueries()逻辑一样，只是将预处理的二维bool数组改为int数组
        /// </summary>
        /// <param name="s"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public IList<bool> CanMakePaliQueries2(string s, int[][] queries)
        {
            int len_s = s.Length, len_q = queries.Length;
            int[] pre = new int[len_s + 1];  // 0: 偶数, 1: 奇数
            for (int i = 0; i < len_s; i++)
                pre[i + 1] = pre[i] ^ (1 << (s[i] - 'a'));

            bool[] result = new bool[len_q];
            int left, right, k, odd;
            for (int i = 0; i < len_q; i++)
            {
                left = queries[i][0]; right = queries[i][1]; k = queries[i][2];
                if (left == right || k >= ((right - left + 1) >> 1))
                {
                    result[i] = true;
                }
                else
                {
                    odd = BitCount(pre[right + 1] ^ pre[left]);
                    if (k >= (odd >> 1)) result[i] = true;
                }
            }

            return result;
        }

        private int BitCount(int u)
        {
            int result = 0;

            while (u > 0)
            {
                result++; u &= u - 1;
            }

            return result;
        }
    }
}
