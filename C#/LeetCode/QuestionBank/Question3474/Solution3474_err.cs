using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3474
{
    public class Solution3474_err : Interface3474
    {
        /// <summary>
        /// 贪心 + 构造
        /// 1. 先把T的位置处理了
        /// 2. 处理F的位置
        ///     如果F位置中已经存在某个位置填充了字符（由T填充）且不同，那么没有填充的位置全部填充'a'
        ///     如果F位置中所有已经填充过了字符的位置（由T填充）都相同，那么没有填充的位置依次处理
        ///         第1个位置填充'a'，不同，后面全部填充'a'，相同，继续处理第2个位置
        ///         第2个位置 ...
        ///         如果到最后一个位置都没有产生不同，最后一个位置改为'b'
        ///     这个贪心又没有证明，直觉上还是不对（应该加上回溯的），先写出来试试...贪心好难
        /// 
        /// 可以通过KMP的思想优化速度，这里先不写了
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public string GenerateString(string str1, string str2)
        {
            int len1 = str1.Length, len2 = str2.Length, len = len1 + len2 - 1;
            char[] buffer = new char[len];
            for (int i = 0; i < len1; i++) if (str1[i] == 'T')
                {
                    for (int j = 0; j < len2; j++)
                    {
                        if (buffer[i + j] == '\0') buffer[i + j] = str2[j]; else if (buffer[i + j] != str2[j]) return "";
                    }
                }
            int lastpos; bool finderr;
            for (int i = 0; i < len1; i++) if (str1[i] == 'F')
                {
                    lastpos = -1; finderr = false;
                    for (int j = 0; j < len2; j++)
                    {
                        if (buffer[i + j] == '\0') buffer[lastpos = i + j] = 'a';
                        if (buffer[i + j] != str2[j]) finderr = true;
                    }
                    if (finderr) continue;
                    if (lastpos == -1) return ""; else buffer[lastpos] = 'b';
                }

            return new string(buffer);
        }
    }
}
