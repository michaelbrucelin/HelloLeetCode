using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0014
{
    public class Solution0014 : Interface0014
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool CheckInclusion(string s1, string s2)
        {
            if (s2.Length < s1.Length) return false;

            int cnt = 26, idx, len1 = s1.Length, len2 = s2.Length;
            int[] cnts = new int[26];
            for (int i = 0; i < len1; i++)
            {
                if (++cnts[idx = s1[i] - 'a'] == 0) cnt++; else if (cnts[idx] == 1) cnt--;
                if (--cnts[idx = s2[i] - 'a'] == 0) cnt++; else if (cnts[idx] == -1) cnt--;
            }
            if (cnt == 26) return true;
            for (int i = len1, j = 0; i < len2; i++, j++) if (s2[i] != s2[j])
                {
                    if (--cnts[idx = s2[i] - 'a'] == 0) cnt++; else if (cnts[idx] == -1) cnt--;
                    if (++cnts[idx = s2[j] - 'a'] == 0) cnt++; else if (cnts[idx] == 1) cnt--;
                    if (cnt == 26) return true;
                }

            return false;
        }
    }
}
