using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0055
{
    public class Solution0055 : Interface0055
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="time"></param>
        /// <param name="fruits"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int GetMinimumTime(int[] time, int[][] fruits, int limit)
        {
            int result = 0;
            foreach (var fruit in fruits)
                result += (fruit[1] + limit - 1) / limit * time[fruit[0]];

            return result;
        }
    }
}
