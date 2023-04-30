using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0824
{
    public class Solution0824 : Interface0824
    {
        /// <summary>
        /// 使用类似C的方式，逐位分析
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public string ToGoatLatin(string sentence)
        {
            StringBuilder result = new StringBuilder();
            HashSet<char> vowel = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            int ptr = -1, id = 1, len = sentence.Length;
            char c, flag = '\0';  // \0表示开始了一个新的单词，' '表示是一个元音字母开头的单词，否则是单词开头的非元音字母
            while (++ptr < len)
            {
                c = sentence[ptr];
                if (c == ' ')
                {
                    if (flag != ' ') result.Append(flag);
                    result.Append($"ma{new string('a', id++)} ");
                    flag = '\0';
                }
                else
                {
                    if (flag == '\0')
                    {
                        if (vowel.Contains(c))
                        {
                            result.Append(c); flag = ' ';
                        }
                        else
                        {
                            flag = c;
                        }
                    }
                    else
                    {
                        result.Append(c);
                    }
                }
            }
            if (flag != ' ') result.Append(flag);
            result.Append($"ma{new string('a', id++)}");

            return result.ToString();
        }

        /// <summary>
        /// 与ToGoatLatin()一样，将if-else改为switch
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public string ToGoatLatin2(string sentence)
        {
            StringBuilder result = new StringBuilder();
            HashSet<char> vowel = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            int ptr = -1, id = 1, len = sentence.Length;
            char c, flag = '\0';  // \0表示开始了一个新的单词，' '表示是一个元音字母开头的单词，否则是单词开头的非元音字母
            while (++ptr < len)
            {
                c = sentence[ptr];
                switch (c)
                {
                    case ' ':
                        if (flag != ' ') result.Append(flag);
                        result.Append($"ma{new string('a', id++)} ");
                        flag = '\0';
                        break;
                    default:
                        switch (flag)
                        {
                            case '\0':
                                if (vowel.Contains(c))
                                {
                                    result.Append(c); flag = ' ';
                                }
                                else
                                {
                                    flag = c;
                                }
                                break;
                            default:
                                result.Append(c);
                                break;
                        }
                        break;
                }
            }
            if (flag != ' ') result.Append(flag);
            result.Append($"ma{new string('a', id++)}");

            return result.ToString();
        }
    }
}
