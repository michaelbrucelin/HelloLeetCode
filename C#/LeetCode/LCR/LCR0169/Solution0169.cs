using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0169
{
    public class Solution0169 : Interface0169
    {
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public char DismantlingAction(string arr)
        {
            int[] cnts = new int[26];
            foreach (char c in arr) cnts[c - 'a']++;
            foreach (char c in arr) if (cnts[c - 'a'] == 1) return c;

            return ' ';
        }
    }
}
