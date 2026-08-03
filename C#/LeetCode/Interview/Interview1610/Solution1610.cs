using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1610
{
    public class Solution1610 : Interface1610
    {
        /// <summary>
        /// 差分
        /// </summary>
        /// <param name="birth"></param>
        /// <param name="death"></param>
        /// <returns></returns>
        public int MaxAliveYear(int[] birth, int[] death)
        {
            const int offset = 1900;
            int len = birth.Length;
            List<int> years = new List<int>();
            for (int i = 0, s, e; i < len; i++)
            {
                s = birth[i] - offset; e = death[i] - offset;
                for (int j = years.Count - 1; j <= e; j++) years.Add(0);
                years[s]++; years[e + 1]--;
            }

            int idx = 0, cnt = years.Count;
            for (int i = 1; i < cnt; i++)
            {
                if ((years[i] += years[i - 1]) > years[idx]) idx = i;
            }
            return idx + offset;
        }
    }
}
