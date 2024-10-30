using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3211
{
    public class Solution3211 : Interface3211
    {
        /// <summary>
        /// DP, BFS
        /// 如果结尾为0，补1，如果结尾为1，补1，再补0
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> ValidStrings(int n)
        {
            if (n == 1) return new List<string>() { "0", "1" };

            List<char[]> buffer = new List<char[]>() { new char[n], new char[n] };
            buffer[0][0] = '0';
            buffer[1][0] = '1';
            for (int i = 1, cnt; i < n; i++)
            {
                cnt = buffer.Count;
                for (int j = 0; j < cnt; j++)
                {
                    buffer[j][i] = '1';
                    if (buffer[j][i - 1] == '1')
                    {
                        char[] _chars = buffer[j].ToArray();
                        _chars[i] = '0';
                        buffer.Add(_chars);
                    }
                }
            }

            List<string> result = new List<string>();
            foreach (char[] _s in buffer) result.Add(new string(_s));
            return result;
        }
    }
}
