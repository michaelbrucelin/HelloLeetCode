using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2409
{
    public class Solution2409_api : Interface2409
    {
        public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
        {
            string arriveStr = string.CompareOrdinal(arriveAlice, arriveBob) < 0 ? arriveBob : arriveAlice;
            string leaveStr = string.CompareOrdinal(leaveAlice, leaveBob) > 0 ? leaveBob : leaveAlice;
            DateTime arrive = DateTime.ParseExact($"1999-{arriveStr}", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime leave = DateTime.ParseExact($"1999-{leaveStr}", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            return leave < arrive ? 0 : (leave - arrive).Days + 1;
        }
    }
}
