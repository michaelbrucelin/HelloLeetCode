using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3986
{
    public class Solution3986_api : Interface3986
    {
        public int SecondsBetweenTimes(string startTime, string endTime)
        {
            TimeOnly t1 = TimeOnly.Parse(startTime);
            TimeOnly t2 = TimeOnly.Parse(endTime);
            return (int)(t2 - t1).TotalSeconds;
        }
    }
}
