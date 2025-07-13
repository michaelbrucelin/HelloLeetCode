using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2410
{
    public class Solution2410 : Interface2410
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="players"></param>
        /// <param name="trainers"></param>
        /// <returns></returns>
        public int MatchPlayersAndTrainers(int[] players, int[] trainers)
        {
            Array.Sort(players);
            Array.Sort(trainers);

            int result = 0, p1 = -1, p2 = -1, len1 = players.Length, len2 = trainers.Length;
            while (++p1 < len1 && ++p2 < len2)
            {
                while (p2 < len2 && trainers[p2] < players[p1]) p2++;
                if (p2 == len2) break;
                result++;
            }

            return result;
        }
    }
}
