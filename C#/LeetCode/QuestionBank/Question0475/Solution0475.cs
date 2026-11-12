using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0475
{
    public class Solution0475 : Interface0475
    {
        /// <summary>
        /// 排序 + 双指针
        /// </summary>
        /// <param name="houses"></param>
        /// <param name="heaters"></param>
        /// <returns></returns>
        public int FindRadius(int[] houses, int[] heaters)
        {
            Array.Sort(houses);
            Array.Sort(heaters);

            int result = 0, p1 = -1, p2 = 0, len1 = houses.Length, len2 = heaters.Length;
            while (++p1 < len1)
            {
                switch (houses[p1] - heaters[p2])
                {
                    case < 0:
                        if (p2 == 0)
                            result = Math.Max(result, heaters[p2] - houses[p1]);
                        else
                            result = Math.Max(result, Math.Min(houses[p1] - heaters[p2 - 1], heaters[p2] - houses[p1]));
                        break;
                    case > 0:
                        while (p2 + 1 < len2 && heaters[p2 + 1] < houses[p1]) p2++;
                        if (p2 == len2 - 1)
                            result = Math.Max(result, houses[p1] - heaters[p2]);
                        else
                            result = Math.Max(result, Math.Min(houses[p1] - heaters[p2], heaters[p2 + 1] - houses[p1]));
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
    }
}
