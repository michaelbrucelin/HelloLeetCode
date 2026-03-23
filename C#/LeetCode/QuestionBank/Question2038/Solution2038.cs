using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2038
{
    public class Solution2038 : Interface2038
    {
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="colors"></param>
        /// <returns></returns>
        public bool WinnerOfGame(string colors)
        {
            int[] cnts = new int[2];
            for (int i = 1, limit = colors.Length - 1; i < limit; i++)
            {
                if (colors[i] == colors[i - 1] && colors[i] == colors[i + 1]) cnts[colors[i] - 'A']++;
            }

            return cnts[0] > cnts[1];
        }

        public bool WinnerOfGame2(string colors)
        {
            int cnt = 1, len = colors.Length;
            int[] cnts = new int[2];
            for (int i = 1; i < len; i++)
            {
                if (colors[i] == colors[i - 1])
                {
                    cnt++;
                }
                else
                {
                    if (cnt > 2) cnts[colors[i - 1] - 'A'] += cnt - 2;
                    cnt = 1;
                }
            }
            if (cnt > 2) cnts[colors[len - 1] - 'A'] += cnt - 2;

            return cnts[0] > cnts[1];
        }
    }
}
