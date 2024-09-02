using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1450
{
    public class Solution1450_api : Interface1450
    {
        public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
        {
            return startTime.Select((val, id) => (id, val))
                            .Select(t => t.val <= queryTime && endTime[t.id] >= queryTime ? 1 : 0)
                            .Sum();
        }

        public int BusyStudent2(int[] startTime, int[] endTime, int queryTime)
        {
            return startTime.Zip(endTime)
                            .Count(t => t.First <= queryTime && t.Second >= queryTime);
        }
    }
}
