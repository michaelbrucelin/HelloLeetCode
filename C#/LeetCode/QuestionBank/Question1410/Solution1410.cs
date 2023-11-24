using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1410
{
    public class Solution1410 : Interface1410
    {
        /// <summary>
        /// 模拟，遍历
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string EntityParser(string text)
        {
            StringBuilder result = new StringBuilder();
            int ptr = 0, len = text.Length;
            while (ptr < len)
            {
                if (text[ptr] != '&')
                {
                    result.Append(text[ptr]); ptr++;
                }
                else
                {
                    if (ptr + 3 < len)
                    {
                        if (text[ptr..(ptr + 4)] == "&gt;") { result.Append('>'); ptr += 4; continue; }
                        if (text[ptr..(ptr + 4)] == "&lt;") { result.Append('<'); ptr += 4; continue; }
                    }
                    if (ptr + 4 < len)
                    {
                        if (text[ptr..(ptr + 5)] == "&amp;") { result.Append('&'); ptr += 5; continue; }
                    }
                    if (ptr + 5 < len)
                    {
                        if (text[ptr..(ptr + 6)] == "&quot;") { result.Append('"'); ptr += 6; continue; }
                        if (text[ptr..(ptr + 6)] == "&apos;") { result.Append("'"); ptr += 6; continue; }
                    }
                    if (ptr + 6 < len)
                    {
                        if (text[ptr..(ptr + 7)] == "&frasl;") { result.Append('/'); ptr += 7; continue; }
                    }
                    result.Append('&'); ptr++;
                }
            }

            return result.ToString();
        }
    }
}
