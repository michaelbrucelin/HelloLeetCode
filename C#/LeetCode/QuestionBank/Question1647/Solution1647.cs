using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1647
{
    public class Solution1647 : Interface1647
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinDeletions(string s)
        {
            int result = 0, len = s.Length;
            int[] cnts = new int[26];
            for (int i = 0; i < len; i++) cnts[s[i] - 'a']++;
            Array.Sort(cnts, (x, y) => y - x);
            HashSet<int> set = [];
            for (int i = 0; i < 26; i++) if (cnts[i] > 0) set.Add(cnts[i]);
            for (int i = 0, diff; i < 25; i++) if (cnts[i] > 0 && cnts[i] == cnts[i + 1])
                {
                    diff = 1;
                    while (set.Contains(cnts[i] - diff) && cnts[i] - diff > 0) diff++;
                    result += diff;
                    set.Add(cnts[i] - diff);
                }

            return result;
        }
    }
}
