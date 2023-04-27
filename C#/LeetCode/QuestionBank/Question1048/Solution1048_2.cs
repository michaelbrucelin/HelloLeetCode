using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1048
{
    public class Solution1048_2 : Interface1048
    {
        /// <summary>
        /// 与Solution1048一样，但是由C指针的形式判断str1是否是str2的前身改为hash表判断
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
                foreach (string str in buckets[k].Keys) for (int i = 0; i < str.Length; i++)
                    {
                        string _str = $"{str.Substring(0, i)}{str.Substring(i + 1)}";
                        if (buckets[k - 1].ContainsKey(_str))
                        {
                            buckets[k][str] = Math.Max(buckets[k][str], buckets[k - 1][_str] + 1);
                            result = Math.Max(result, buckets[k][str]);
                        }
                    }
            }

            return result;
        }
    }
}
