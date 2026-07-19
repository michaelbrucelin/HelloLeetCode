using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3986
{
    public class Solution3986 : Interface3986
    {
        /// <summary>
        /// 六十进制
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int SecondsBetweenTimes(string startTime, string endTime)
        {
            int t1 = Convert.ToInt32(startTime[0..2]) * 3600 + Convert.ToInt32(startTime[3..5]) * 60 + Convert.ToInt32(startTime[6..8]);
            int t2 = Convert.ToInt32(endTime[0..2]) * 3600 + Convert.ToInt32(endTime[3..5]) * 60 + Convert.ToInt32(endTime[6..8]);
            return t2 - t1;
        }
    }
}
