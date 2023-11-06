using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0318
{
    public class Solution0318 : Interface0318
    {
        private const int alletter = (1 << 26) - 1;

        /// <summary>
        /// 暴力枚举，位运算
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int MaxProduct(string[] words)
        {
            int result = 0;
            for (int i = 0; i < words.Length; i++)
            {
                int mask_i = GetMask(words[i]);
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (words[i].Length * words[j].Length <= result) continue;

                    int mask_j = GetMask(words[j]);
                    if ((mask_i & mask_j) == 0) result = words[i].Length * words[j].Length;
                }
            }

            return result;
        }

        /// <summary>
        /// 贪心
        /// 与MaxProduct()逻辑一样，但是在暴力枚举之前先排序，这样可以提前剪枝
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int MaxProduct2(string[] words)
        {
            int result = 0, len = words.Length;
            Array.Sort(words, (s1, s2) => s2.Length - s1.Length);
            for (int i = 0, mask_i; i < len - 1; i++)
            {
                if ((mask_i = GetMask(words[i])) == alletter) continue;
                if (words[i].Length * words[i + 1].Length <= result) break;
                for (int j = i + 1, product; j < len; j++)
                {
                    if ((product = words[i].Length * words[j].Length) <= result) break;
                    if ((mask_i & GetMask(words[j])) == 0)
                    {
                        result = product; break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 与MaxProduct2()逻辑一致，但是在排序之前先对数组做了去重
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int MaxProduct3(string[] words)
        {
            words = new HashSet<string>(words).ToArray();
            int result = 0, len = words.Length;
            Array.Sort(words, (s1, s2) => s2.Length - s1.Length);
            for (int i = 0, mask_i; i < len - 1; i++)
            {
                if ((mask_i = GetMask(words[i])) == alletter) continue;
                if (words[i].Length * words[i + 1].Length <= result) break;
                for (int j = i + 1, product; j < len; j++)
                {
                    if ((product = words[i].Length * words[j].Length) <= result) break;
                    if ((mask_i & GetMask(words[j])) == 0)
                    {
                        result = product; break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 与MaxProduct3()逻辑一样，但是预处理了全部字符串的mask
        /// 
        /// 还可以继续优化，例如按照mask去重复，而不是word自身去重复，这里就不继续优化了
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int MaxProduct4(string[] words)
        {
            words = new HashSet<string>(words).ToArray();
            int result = 0, len = words.Length;
            Array.Sort(words, (s1, s2) => s2.Length - s1.Length);
            int[] mask = new int[len];
            for (int i = 0; i < len; i++) mask[i] = GetMask(words[i]);

            for (int i = 0; i < len - 1; i++)
            {
                if (mask[i] == alletter) continue;
                if (words[i].Length * words[i + 1].Length <= result) break;
                for (int j = i + 1, product; j < len; j++)
                {
                    if ((product = words[i].Length * words[j].Length) <= result) break;
                    if ((mask[i] & mask[j]) == 0)
                    {
                        result = product; break;
                    }
                }
            }

            return result;
        }

        private int GetMask(string word)
        {
            int result = 0;
            for (int i = 0; i < word.Length; i++)
            {
                result |= 1 << (word[i] - 'a');
                if (result == alletter) break;
            }

            return result;
        }
    }
}
