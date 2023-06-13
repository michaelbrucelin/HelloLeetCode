using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1370
{
    public class Solution1370 : Interface1370
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string SortString(string s)
        {
            int len = s.Length;
            int[] freq = new int[26];
            for (int i = 0; i < len; i++) freq[s[i] - 'a']++;

            char[] result = new char[len];
            int id = 0; bool flag = true;   // true a-z, false z-a
            while (id < len)
            {
                if (flag)
                {
                    for (int i = 0; i < 26; i++)
                    {
                        if (freq[i] > 0)
                        {
                            result[id++] = (char)(i + 'a'); freq[i]--;
                        }
                    }
                }
                else
                {
                    for (int i = 25; i >= 0; i--)
                    {
                        if (freq[i] > 0)
                        {
                            result[id++] = (char)(i + 'a'); freq[i]--;
                        }
                    }
                }
                flag = !flag;
            }

            return new string(result);
        }

        /// <summary>
        /// 与SortString()一样，不需要使用bool值记录上一次是升序还是降序
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string SortString2(string s)
        {
            int len = s.Length;
            int[] freq = new int[26];
            for (int i = 0; i < len; i++) freq[s[i] - 'a']++;

            char[] result = new char[len];
            int id = 0;
            while (id < len)
            {
                for (int i = 0; i < 26; i++)
                {
                    if (freq[i] > 0)
                    {
                        result[id++] = (char)(i + 'a'); freq[i]--;
                    }
                }
                for (int i = 25; i >= 0; i--)
                {
                    if (freq[i] > 0)
                    {
                        result[id++] = (char)(i + 'a'); freq[i]--;
                    }
                }
            }

            return new string(result);
        }
    }
}
