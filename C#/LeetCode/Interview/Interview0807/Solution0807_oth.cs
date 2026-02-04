using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0807
{
    public class Solution0807_oth : Interface0807
    {
        /// <summary>
        /// 这个解法精彩绝伦，解释见Solution0807_oth.md
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public string[] Permutation(string S)
        {
            List<char[]> buffer = new List<char[]>() { S.ToCharArray() };
            int len = S.Length; char temp;
            for (int i = 0, cnt = buffer.Count; i < len; i++, cnt = buffer.Count) for (int idx = 0; idx < cnt; idx++)
                {
                    for (int j = i + 1; j < len; j++)
                    {
                        char[] chars = [.. buffer[idx]];
                        temp = chars[i]; chars[i] = chars[j]; chars[j] = temp;
                        buffer.Add(chars);
                    }
                }

            len = buffer.Count;
            string[] result = new string[len];
            for (int i = 0; i < len; i++) result[i] = new string(buffer[i]);
            return result;
        }
    }
}
