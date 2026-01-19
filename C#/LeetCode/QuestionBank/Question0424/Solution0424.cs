using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0424
{
    public class Solution0424 : Interface0424
    {
        /// <summary>
        /// 双指针，滑动窗口
        /// 窗口内除数量最多的字母外，其余字母总数量小于等于k即可
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CharacterReplacement(string s, int k)
        {
            int result = 0, p1 = 0, p2 = -1, maxcnt = 0, len = s.Length;
            int[] cnts = new int[26];
            while (p2 < len)
            {
                while (p2 - p1 + 1 - maxcnt <= k && ++p2 < len) maxcnt = Math.Max(maxcnt, ++cnts[s[p2] - 'A']);
                result = Math.Max(result, p2 - p1);
                cnts[s[p1++] - 'A']--;
                if (cnts[s[p1 - 1] - 'A'] == maxcnt - 1) maxcnt = 0; for (int i = 0; i < 26; i++) maxcnt = Math.Max(maxcnt, cnts[i]);
            }

            return result;
        }
    }
}
