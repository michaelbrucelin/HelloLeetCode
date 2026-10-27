using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0691
{
    public class Solution0691 : Interface0691
    {
        /// <summary>
        /// DFS
        /// 没写完，先不写了
        /// </summary>
        /// <param name="stickers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MinStickers(string[] stickers, string target)
        {
            int len = stickers.Length;
            int[][] digits = new int[len][];
            for (int i = 0; i < len; i++)
            {
                digits[i] = new int[26];
                foreach (char c in stickers[i]) digits[i][c - 'a']++;
            }

            int tcnt = 0;
            int[] tarr = new int[26];
            foreach (char c in target) if (++tarr[c - 'a'] == 1) tcnt++;

            int result = int.MaxValue;

            return result != int.MaxValue ? result : -1;
        }
    }
}
