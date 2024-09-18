using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2332
{
    public class Solution2332 : Interface2332
    {
        /// <summary>
        /// 模拟，双指针，类归并排序
        /// 如果最后一辆车没满，结果为最后一辆车的时间
        /// 如果最后一辆车满了，结果为最后上车人的时间-1
        /// </summary>
        /// <param name="buses"></param>
        /// <param name="passengers"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity)
        {
            Array.Sort(buses);
            Array.Sort(passengers);

            int pb = -1, lb = buses.Length, pp = 0, lp = passengers.Length, cnt = 0;
            while (++pb < lb)
            {
                cnt = 0;
                while (cnt < capacity && pp < lp && passengers[pp] <= buses[pb])
                {
                    cnt++; pp++;
                }
                if (pp == lp) break;
            }

            int result = (cnt < capacity || pb < lb - 1) ? buses[^1] : passengers[pp - 1] - 1;
            // 不能与别的乘客同时刻到达
            for (int i = passengers.Length - 1; i >= 0; i--)
            {
                if (passengers[i] < result) break; else if (passengers[i] == result) result--;
            }
            return result;
        }
    }
}
