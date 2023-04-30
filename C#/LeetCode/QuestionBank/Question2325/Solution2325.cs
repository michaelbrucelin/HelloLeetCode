using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2325
{
    public class Solution2325 : Interface2325
    {
        public string DecodeMessage(string key, string message)
        {
            Dictionary<char, char> dic = new Dictionary<char, char>() { { ' ', ' ' } };
            for (int i = 0, j = 97; i < key.Length; i++)
            {
                if (!dic.ContainsKey(key[i])) dic.Add(key[i], (char)j++);
                if (j == 123) break;
            }

            char[] result = new char[message.Length];
            for (int i = 0; i < message.Length; i++) result[i] = dic[message[i]];

            return new string(result);
        }

        /// <summary>
        /// 将字典改为数组
        /// </summary>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public string DecodeMessage2(string key, string message)
        {
            char[] map = new char[26];
            for (int i = 0, j = 97; i < key.Length; i++)
            {
                if (key[i] != ' ' && map[key[i] - 'a'] == '\0') map[key[i] - 'a'] = (char)j++;
                if (j == 123) break;
            }

            char[] result = new char[message.Length];
            for (int i = 0; i < message.Length; i++)
                result[i] = message[i] == ' ' ? ' ' : map[message[i] - 'a'];

            return new string(result);
        }
    }
}
