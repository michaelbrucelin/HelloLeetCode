using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3296
{
    public class Solution3296 : Interface3296
    {
        /// <summary>
        /// 二分查找
        /// 假定worktime为wt，则降低高度为h需要的时间为：t = wt * h(h+1)/2，可解出：h = Sqrt(2t/wt+0.25)-0.5
        /// </summary>
        /// <param name="mountainHeight"></param>
        /// <param name="workerTimes"></param>
        /// <returns></returns>
        public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes)
        {
            long result, minwt = long.MaxValue;
            foreach (int wt in workerTimes) minwt = Math.Min(minwt, wt);
            result = minwt * mountainHeight * (mountainHeight + 1) >> 1;
            long left = 1, right = result, mid, height;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                height = 0;
                foreach (int wt in workerTimes)
                {
                    height += (long)Math.Floor(Math.Sqrt((mid << 1) / wt + 0.25) - 0.5);
                }
                if (height >= mountainHeight)
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
