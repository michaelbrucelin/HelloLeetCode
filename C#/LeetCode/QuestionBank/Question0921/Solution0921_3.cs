using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0921
{
    public class Solution0921_3 : Interface0921
    {
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinAddToMakeValid(string s)
        {
            int lcnt = 0, result = 0;
            foreach (char c in s) switch (c)
                {
                    case '(': lcnt++; break;
                    case ')': if (lcnt > 0) lcnt--; else result++; break;
                    default: break;
                }
            result += lcnt;

            return result;
        }
    }
}
