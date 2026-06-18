using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1344
{
    public class Solution1344 : Interface1344
    {
        /// <summary>
        /// 小学数学
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public double AngleClock(int hour, int minutes)
        {
            double HH = hour * 30 + minutes / 2D, MI = minutes * 6;
            double angle = Math.Abs(MI - HH);

            return Math.Min(angle, 360 - angle);
        }
    }
}
