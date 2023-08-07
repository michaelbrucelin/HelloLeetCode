using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2660
{
    public class Solution2660 : Interface2660
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns></returns>
        public int IsWinner(int[] player1, int[] player2)
        {
            int score1 = player1[0], score2 = player2[0], len = player1.Length;
            if (len > 1)
            {
                score1 += player1[1] * (player1[0] == 10 ? 2 : 1);
                score2 += player2[1] * (player2[0] == 10 ? 2 : 1);
                for (int i = 2; i < len; i++)
                {
                    score1 += player1[i] * ((player1[i - 1] == 10 || player1[i - 2] == 10) ? 2 : 1);
                    score2 += player2[i] * ((player2[i - 1] == 10 || player2[i - 2] == 10) ? 2 : 1);
                }
            }

            return score1 > score2 ? 1 : (score1 < score2 ? 2 : 0);
        }
    }
}
