using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3439
{
    public class Solution3439 : Interface3439
    {
        /// <summary>
        /// 滑动窗口
        /// 移动k个会议（保持原顺序），即相邻的k+1个“间隙”可以连在一起
        /// </summary>
        /// <param name="eventTime"></param>
        /// <param name="k"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime)
        {
            int result = 0, len = startTime.Length;
            if (len <= k)
            {
                result = eventTime;
                for (int i = 0; i < len; i++) result -= endTime[i] - startTime[i];
            }
            else
            {
                List<int> gaps = new List<int>();
                gaps.Add(startTime[0]);
                for (int i = 1; i < len; i++) gaps.Add(startTime[i] - endTime[i - 1]);
                gaps.Add(eventTime - endTime[^1]);
                int window = 0;
                for (int i = 0; i <= k; i++) window += gaps[i];
                result = window;
                for (int i = k + 1; i <= len; i++) result = Math.Max(result, window += gaps[i] - gaps[i - k - 1]);
            }

            return result;
        }
    }
}
