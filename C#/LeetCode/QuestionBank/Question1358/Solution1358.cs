using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1358
{
    public class Solution1358 : Interface1358
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumberOfSubstrings(string s)
        {
            int result = 0, cnt = 0, p1 = 0, p2 = -1, len = s.Length;
            int[] cnts = new int[3];
            while (p1 < len)
            {
                while (cnt < 3 && ++p2 < len) if (++cnts[s[p2] - 'a'] == 1) cnt++;
                if (cnt < 3) break;
                result += len - p2;
                if (--cnts[s[p1++] - 'a'] == 0) cnt--;
            }

            return result;
        }
    }
}
