using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1615
{
    public class Solution1615 : Interface1615
    {
        /// <summary>
        /// 分析
        /// 1. 相同位置相同，是一次猜中
        /// 2. 不用位置相同，是一次伪猜中
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public int[] MasterMind(string solution, string guess)
        {
            int[] result = new int[2];
            Dictionary<char, int> map = new Dictionary<char, int>() { { 'R', 0 }, { 'G', 1 }, { 'B', 2 }, { 'Y', 3 } };
            int[] freq_s = new int[4], freq_g = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if (solution[i] == guess[i]) result[0]++;
                else
                {
                    freq_s[map[solution[i]]]++; freq_g[map[guess[i]]]++;
                }
            }
            for (int i = 0; i < 4; i++) result[1] += Math.Min(freq_s[i], freq_g[i]);

            return result;
        }
    }
}
