using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0696
{
    public class Solution0696 : Interface0696
    {
        /// <summary>
        /// 数学
        /// 1. 预处理一个数组，记录的是字符串中连续0与1的数量
        /// 2. 数组每相邻两个元素可构成的结果是二者的较小者
        /// 例如
        /// s = "00110011" --> {2, 2, 2, 2}
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountBinarySubstrings(string s)
        {
            List<int> list = new List<int>();
            int cnt = 1, ptr = 1, len = s.Length;
            while (ptr < len && s[ptr] == s[ptr - 1]) { cnt++; ptr++; }
            if (ptr == len) return 0;

            for (int i = ptr; i < len; i++)
            {
                if (s[i] == s[i - 1])
                {
                    cnt++;
                }
                else
                {
                    list.Add(cnt); cnt = 1;
                }
            }
            list.Add(cnt);

            int result = 0;
            for (int i = 1; i < list.Count; i++) result += Math.Min(list[i - 1], list[i]);
            return result;
        }
    }
}
