using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3612
{
    public class Solution3612 : Interface3612
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ProcessStr(string s)
        {
            List<char> buffer = new List<char>();
            int idx = 0;
            foreach (char c in s) switch (c)
                {
                    case '*':
                        if (idx > 0) idx--;
                        break;
                    case '#':
                        for (int i = 0, j = idx; i < j; i++)
                        {
                            if (idx < buffer.Count) buffer[idx] = buffer[i]; else buffer.Add(buffer[i]);
                            idx++;
                        }
                        break;
                    case '%':
                        for (int i = 0, j = idx - 1; i < j; i++, j--) (buffer[i], buffer[j]) = (buffer[j], buffer[i]);
                        break;
                    default:
                        if (idx < buffer.Count) buffer[idx] = c; else buffer.Add(c);
                        idx++;
                        break;
                }

            return new string([.. buffer[0..idx]]);
        }

        /// <summary>
        /// 逻辑同ProcessStr()，使用StringBuilder试试
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ProcessStr2(string s)
        {
            StringBuilder buffer = new StringBuilder();
            foreach (char c in s) switch (c)
                {
                    case '*':
                        if (buffer.Length > 0) buffer.Length--;
                        break;
                    case '#':
                        buffer.Append(buffer);
                        break;
                    case '%':
                        for (int i = 0, j = buffer.Length - 1; i < j; i++, j--) (buffer[i], buffer[j]) = (buffer[j], buffer[i]);
                        break;
                    default:
                        buffer.Append(c);
                        break;
                }

            return buffer.ToString();
        }
    }
}
