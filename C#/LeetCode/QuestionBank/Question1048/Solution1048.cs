using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1048
{
    public class Solution1048 : Interface1048
    {
        /// <summary>
        /// 类DP
        /// 1. 将word按照长度放入对应的桶（字典，value默认为1）中，根据题意，需要16个桶
        ///     之所以用字典而不是列表，是为了自动去重复
        ///     之所以用字典而不是集合，是为了保存结果，结果表示如果以当前word结尾的链的最大长度
        /// 2. 如果链以第一个桶中的word结尾，显然链的长度为1（这也是为什么字典的值为1）
        /// 3. 第1层循环：从前向后遍历每个桶
        ///         第2层循环：遍历桶中的每一个元素str2
        ///              第3层循环：遍历前一个桶中的每一个元素str1
        ///                   判断str1是否是str2的前身，如果是，str2的值就是MAX(当前str2的值，str1的值+1)
        ///                                             否则，  str2的值不变
        /// 4. 结果就是所有value的最大值
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int LongestStrChain(string[] words)
        {
            Dictionary<string, int>[] buckets = new Dictionary<string, int>[16];      // 题目规定单词长度不超过16
            for (int i = 0; i < 16; i++) buckets[i] = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++) buckets[words[i].Length - 1].TryAdd(words[i], 1);

            int result = 1;
            for (int k = 1; k < 16; k++)
            {
                foreach (string str2 in buckets[k].Keys) foreach (string str1 in buckets[k - 1].Keys)
                    {
                        if (IsPredecessor(str1, str2))
                        {
                            buckets[k][str2] = Math.Max(buckets[k][str2], buckets[k - 1][str1] + 1);
                            result = Math.Max(result, buckets[k][str2]);
                        }
                    }
            }

            return result;
        }

        private bool IsPredecessor(string str1, string str2)
        {
            int len1 = str1.Length, len2 = str2.Length;
            if (len1 + 1 != len2) return false;
            for (int j = 0; j < len2; j++)       // 忽略str2的第j个字符
            {
                for (int i = 0; i < j; i++) if (str1[i] != str2[i]) goto Continue;
                for (int i = j; i < len1; i++) if (str1[i] != str2[i + 1]) goto Continue;
                return true;
                Continue:;
            }

            return false;
        }
    }
}
