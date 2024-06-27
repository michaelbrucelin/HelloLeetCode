using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2734
{
    public class Solution2734 : Interface2734
    {
        /// <summary>
        /// 贪心
        /// 从前向后找第一个不含a的子字符串操作即可。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string SmallestString(string s)
        {
            int p = 0, len = s.Length;
            char[] buffer = s.ToCharArray();
            while (p < len && buffer[p] == 'a') p++;
            if (p == len)
            {
                buffer[^1] = 'z';
            }
            else
            {
                while (p < len && buffer[p] != 'a')
                {
                    buffer[p] = (char)(buffer[p] - 1);
                    p++;
                }
            }

            return new string(buffer);
        }
    }
}
