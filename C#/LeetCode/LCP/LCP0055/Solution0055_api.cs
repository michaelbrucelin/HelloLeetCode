using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0055
{
    public class Solution0055_api : Interface0055
    {
        public int GetMinimumTime(int[] time, int[][] fruits, int limit)
        {
            return fruits.Select(fruit => (fruit[1] + limit - 1) / limit * time[fruit[0]]).Sum();
        }
    }
}
