using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0455
{
    public class Solution0455 : Interface0455
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g); Array.Sort(s);
            int result = 0, ptrg = 0, ptrs = 0;
            while (ptrg < g.Length && ptrs < s.Length)
            {
                if (s[ptrs] >= g[ptrg])
                {
                    result++; ptrg++;
                }
                ptrs++;
            }

            return result;
        }
    }
}
