using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2347
{
    public class Solution2347 : Interface2347
    {
        public string BestHand(int[] ranks, char[] suits)
        {
            bool isFlush = true;
            for (int i = 1; i < 5; i++) if (suits[i] != suits[0]) { isFlush = false; break; }
            if (isFlush) return "Flush";

            int[] freq = new int[13];
            for (int i = 0; i < 5; i++) freq[ranks[i] - 1]++;
            int max = 0;
            for (int i = 0; i < 13; i++) max = Math.Max(max, freq[i]);

            switch (max)
            {
                case >= 3:
                    return "Three of a Kind";
                case 2:
                    return "Pair";
                default:
                    return "High Card";
            }
        }

        public string BestHand2(int[] ranks, char[] suits)
        {
            if (suits.Distinct().Count() == 1) return "Flush";

            int max = ranks.GroupBy(i => i).Select(g => g.Count()).Max();

            switch (max)
            {
                case >= 3:
                    return "Three of a Kind";
                case 2:
                    return "Pair";
                default:
                    return "High Card";
            }
        }
    }
}
