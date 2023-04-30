using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2409
{
    public class Solution2409_2 : Interface2409
    {
        private static readonly int[] days = new int[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };

        public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
        {
            string arrive = string.CompareOrdinal(arriveAlice, arriveBob) < 0 ? arriveBob : arriveAlice;
            string leave = string.CompareOrdinal(leaveAlice, leaveBob) > 0 ? leaveBob : leaveAlice;

            int diff = string.CompareOrdinal(arrive, leave);
            if (diff > 0) return 0; else if (diff == 1) return 1;

            int arriveMM = int.Parse(arrive[0..2]), arriveDD = int.Parse(arrive[3..]);
            int leaveMM = int.Parse(leave[0..2]), leaveDD = int.Parse(leave[3..]);
            if (leaveMM == arriveMM)
            {
                return leaveDD - arriveDD + 1;
            }
            else  // if (leaveMM > arriveMM)
            {
                return (days[leaveMM - 1] + leaveDD) - (days[arriveMM - 1] + arriveDD) + 1;
            }
        }
    }
}
