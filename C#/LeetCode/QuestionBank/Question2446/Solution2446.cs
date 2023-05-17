using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2446
{
    public class Solution2446 : Interface2446
    {
        /// <summary>
        /// 分析
        /// 字符串比较
        /// </summary>
        /// <param name="event1"></param>
        /// <param name="event2"></param>
        /// <returns></returns>
        public bool HaveConflict(string[] event1, string[] event2)
        {
            // return !(string.CompareOrdinal(event1[1], event2[0]) < 0 || string.CompareOrdinal(event2[1], event1[0]) < 0);
            return string.CompareOrdinal(event1[1], event2[0]) >= 0 && string.CompareOrdinal(event2[1], event1[0]) >= 0;
        }

        /// <summary>
        /// 分析
        /// 整型比较
        /// </summary>
        /// <param name="event1"></param>
        /// <param name="event2"></param>
        /// <returns></returns>
        public bool HaveConflict2(string[] event1, string[] event2)
        {
            // return !(int.Parse(event1[1][0..2]) * 100 + int.Parse(event1[1][3..]) - int.Parse(event2[0][0..2]) * 100 - int.Parse(event2[0][3..]) < 0 ||
            //          int.Parse(event2[1][0..2]) * 100 + int.Parse(event2[1][3..]) - int.Parse(event1[0][0..2]) * 100 - int.Parse(event1[0][3..]) < 0);
            return int.Parse(event1[1][0..2]) * 100 + int.Parse(event1[1][3..]) - int.Parse(event2[0][0..2]) * 100 - int.Parse(event2[0][3..]) >= 0 &&
                   int.Parse(event2[1][0..2]) * 100 + int.Parse(event2[1][3..]) - int.Parse(event1[0][0..2]) * 100 - int.Parse(event1[0][3..]) >= 0;
        }
    }
}
