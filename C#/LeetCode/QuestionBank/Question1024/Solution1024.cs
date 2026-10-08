using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1024
{
    public class Solution1024 : Interface1024
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="clips"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int VideoStitching(int[][] clips, int time)
        {
            Array.Sort(clips, (x, y) => x[0] != y[0] ? x[0] - y[0] : x[1] - y[1]);
            if (clips[0][0] > 0) return -1;

            int result = 0, ptr = 0, reach = 0, next = 0, len = clips.Length;
            while (ptr < len && reach < time)
            {
                while (ptr < len && clips[ptr][0] <= reach) { next = Math.Max(next, clips[ptr][1]); ptr++; }
                if (next <= reach) return -1;
                reach = next;
                result++;
            }

            return reach >= time ? result : -1;
        }
    }
}
