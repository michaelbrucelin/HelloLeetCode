using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2810
{
    public class Solution2810_error : Interface2810
    {
        /// <summary>
        /// 三指针
        /// 三个指针分别指向左端点、右端点、字符i
        /// 
        /// 题目理解错了，是翻转之前全部的输入，而不是上次i与这次i之间的输入
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string FinalString(string s)
        {
            StringBuilder result = new StringBuilder();
            int pl = 0, pr, pi, len = s.Length; bool flag;
            while (pl < len && s[pl] == 'i') pl++;
            while (pl < len)
            {
                pr = pl;
                while (pr + 1 < len && s[pr + 1] != 'i') pr++;
                if (pr == len - 1)
                {
                    result.Append(s[pl..]);
                    break;
                }
                else
                {
                    pi = pr + 1; flag = true;
                    while (pi + 1 < len && s[pi + 1] == 'i') { pi++; flag = !flag; }
                    result.Append(flag ? new string(s[pl..(pr + 1)].Reverse().ToArray()) : s[pl..(pr + 1)]);
                    pl = pi + 1;
                }
            }

            return result.ToString();
        }
    }
}
