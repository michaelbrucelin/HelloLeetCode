using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2390
{
    public class Solution2390_2 : Interface2390
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveStars(string s)
        {
            List<char> list = new List<char>();
            int p = 0;
            foreach (char c in s)
            {
                if (c == '*')
                {
                    if (p > 0) p--;
                }
                else
                {
                    if (list.Count > p) list[p] = c; else list.Add(c);
                    p++;
                }
            }

            return new string(list[0..p].ToArray());
        }
    }
}
