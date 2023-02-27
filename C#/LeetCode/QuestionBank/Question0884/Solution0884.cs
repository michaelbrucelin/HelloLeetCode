using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0884
{
    public class Solution0884 : Interface0884
    {
        public string[] UncommonFromSentences(string s1, string s2)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int left = 0, right, len = s1.Length;
            while (left < len)
            {
                right = left + 1;
                while (right < len && s1[right] != ' ') right++;
                string str = s1.Substring(left, right - left);
                if (dic.ContainsKey(str)) dic[str]++; else dic.Add(str, 1);
                left = right + 1;
            }
            left = 0; len = s2.Length;
            while (left < len)
            {
                right = left + 1;
                while (right < len && s2[right] != ' ') right++;
                string str = s2.Substring(left, right - left);
                if (dic.ContainsKey(str)) dic[str]++; else dic.Add(str, 1);
                left = right + 1;
            }

            return dic.Where(kv => kv.Value == 1).Select(kv => kv.Key).ToArray();
        }

        /// <summary>
        /// 与UncommonFromSentences()逻辑一样，使用代码手段，精简代码
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public string[] UncommonFromSentences2(string s1, string s2)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int left = 0, right, len = s1.Length; string str = s1; bool repeat = true;
            Repeat:
            while (left < len)
            {
                right = left + 1;
                while (right < len && str[right] != ' ') right++;
                string key = str.Substring(left, right - left);
                if (dic.ContainsKey(key)) dic[key]++; else dic.Add(key, 1);
                left = right + 1;
            }
            if (repeat)
            {
                left = 0; len = s2.Length; str = s2; repeat = false;
                goto Repeat;
            }

            return dic.Where(kv => kv.Value == 1).Select(kv => kv.Key).ToArray();
        }

        /// <summary>
        /// 与UncommonFromSentences()逻辑一样，使用代码手段，精简代码
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public string[] UncommonFromSentences2_1(string s1, string s2)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            (int left, int len, string str)[] args = new (int left, int len, string str)[] { (0, s1.Length, s1), (0, s2.Length, s2) };
            for (int i = 0; i < args.Length; i++)
            {
                int left = args[i].left, len = args[i].len, right; string str = args[i].str;
                while (left < len)
                {
                    right = left + 1;
                    while (right < len && str[right] != ' ') right++;
                    string _str = str.Substring(left, right - left);
                    if (dic.ContainsKey(_str)) dic[_str]++; else dic.Add(_str, 1);
                    left = right + 1;
                }
            }

            return dic.Where(kv => kv.Value == 1).Select(kv => kv.Key).ToArray();
        }

        /// <summary>
        /// 与UncommonFromSentences()逻辑一样，将字符串截取换成StringBuilder
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public string[] UncommonFromSentences3(string s1, string s2)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            StringBuilder sb = new StringBuilder();
            int left = 0, right, len = s1.Length;
            while (left < len)
            {
                right = left; sb.Clear();
                while (right < len && s1[right] != ' ') sb.Append(s1[right++]);
                string str = sb.ToString();
                if (dic.ContainsKey(str)) dic[str]++; else dic.Add(str, 1);
                left = right + 1;
            }
            left = 0; len = s2.Length;
            while (left < len)
            {
                right = left; sb.Clear();
                while (right < len && s2[right] != ' ') sb.Append(s2[right++]);
                string str = sb.ToString();
                if (dic.ContainsKey(str)) dic[str]++; else dic.Add(str, 1);
                left = right + 1;
            }

            return dic.Where(kv => kv.Value == 1).Select(kv => kv.Key).ToArray();
        }

        /// <summary>
        /// 与UncommonFromSentences3()逻辑一样，使用代码手段，精简代码
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public string[] UncommonFromSentences4(string s1, string s2)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            StringBuilder sb = new StringBuilder();
            int left = 0, right, len = s1.Length; string str = s1; bool repeat = true;
            Repeat:
            while (left < len)
            {
                right = left; sb.Clear();
                while (right < len && str[right] != ' ') sb.Append(str[right++]);
                string key = sb.ToString();
                if (dic.ContainsKey(key)) dic[key]++; else dic.Add(key, 1);
                left = right + 1;
            }
            if (repeat)
            {
                left = 0; len = s2.Length; str = s2; repeat = false;
                goto Repeat;
            }

            return dic.Where(kv => kv.Value == 1).Select(kv => kv.Key).ToArray();
        }

        /// <summary>
        /// 与UncommonFromSentences3()逻辑一样，使用代码手段，精简代码
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public string[] UncommonFromSentences4_1(string s1, string s2)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            StringBuilder sb = new StringBuilder();
            (int left, int len, string str)[] args = new (int left, int len, string str)[] { (0, s1.Length, s1), (0, s2.Length, s2) };
            for (int i = 0; i < args.Length; i++)
            {
                int left = args[i].left, len = args[i].len, right; string str = args[i].str;
                while (left < len)
                {
                    right = left; sb.Clear();
                    while (right < len && str[right] != ' ') sb.Append(str[right++]);
                    string _str = sb.ToString();
                    if (dic.ContainsKey(_str)) dic[_str]++; else dic.Add(_str, 1);
                    left = right + 1;
                }
            }

            return dic.Where(kv => kv.Value == 1).Select(kv => kv.Key).ToArray();
        }

        /// <summary>
        /// 使用API
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public string[] UncommonFromSentences5(string s1, string s2)
        {
            return s1.Split(' ').Concat(s2.Split(" "))
                     .GroupBy(str => str)
                     .Where(g => g.Count() == 1)
                     .Select(g => g.Key)
                     .ToArray();
        }
    }
}
