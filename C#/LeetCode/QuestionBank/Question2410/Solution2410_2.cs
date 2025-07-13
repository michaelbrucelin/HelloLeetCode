using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2410
{
    public class Solution2410_2 : Interface2410
    {
        /// <summary>
        /// 二分法
        /// 逻辑与Solution2410相同，只是将双指针改为二分法
        /// </summary>
        /// <param name="players"></param>
        /// <param name="trainers"></param>
        /// <returns></returns>
        public int MatchPlayersAndTrainers(int[] players, int[] trainers)
        {
            int len1 = players.Length, len2 = trainers.Length;
            if (len1 == 1)
            {
                for (int i = 0; i < len2; i++) if (players[0] <= trainers[i]) return 1;
                return 0;
            }
            if (len2 == 1)
            {
                for (int i = 0; i < len1; i++) if (players[i] <= trainers[0]) return 1;
                return 0;
            }

            Array.Sort(players);
            Array.Sort(trainers);
            int result = 0, p1 = -1, p2 = -1;
            while (++p1 < len1 && ++p2 < len2)
            {
                p2 = binarySearch(p2, players[p1]);
                if (p2 == len2) break;
                result++;
            }

            return result;

            int binarySearch(int start, int target)
            {
                int result = len2, left = start, right = len2 - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (trainers[mid] >= target)
                    {
                        result = mid; right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                return result;
            }
        }
    }
}
