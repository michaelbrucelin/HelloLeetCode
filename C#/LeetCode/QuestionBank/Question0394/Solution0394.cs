using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0394
{
    public class Solution0394 : Interface0394
    {
        /// <summary>
        /// 分治
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string DecodeString(string s)
        {
            return dv(0, s.Length - 1);

            string dv(int l, int r)
            {
                StringBuilder result = new StringBuilder();

                int p = l,time;
                while (p <= r)
                {
                    if (char.IsAsciiDigit(s[p]))
                    {
                        time = s[p] & 15;
                        while (char.IsAsciiDigit(s[++p])) time = time * 10 + (s[p] & 15);
                    }
                    else  // if (char.IsAsciiLower(s[p]))
                    { 
                    
                    }
                }

                return result.ToString();
            }
        }
    }
}
