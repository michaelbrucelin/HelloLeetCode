using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0846
{
    public class Solution0846 : Interface0846
    {
        /// <summary>
        /// Hash
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="groupSize"></param>
        /// <returns></returns>
        public bool IsNStraightHand(int[] hand, int groupSize)
        {
            if (hand.Length % groupSize != 0) return false;

            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (int x in hand) if (freq.TryGetValue(x, out int val)) freq[x] = ++val; else freq.Add(x, 1);

            int start, cnt;
            while (freq.Count > 0)
            {
                start = int.MaxValue;
                foreach (int x in freq.Keys) start = Math.Min(start, x);
                cnt = freq[start];
                for (int i = 0; i < groupSize; i++)
                {
                    if (freq.TryGetValue(start + i, out int val))
                    {
                        if (val < cnt) return false;
                        if (val != cnt) freq[start + i] = val - cnt; else freq.Remove(start + i);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
