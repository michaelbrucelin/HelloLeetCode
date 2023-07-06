using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2178
{
    public class Solution2178_2 : Interface2178
    {
        /// <summary>
        /// 贪心
        /// 本质上与Solution2178一样，更直接的贪心
        /// </summary>
        /// <param name="finalSum"></param>
        /// <returns></returns>
        public IList<long> MaximumEvenSplit(long finalSum)
        {
            if ((finalSum & 1) != 0) return new List<long>();

            List<long> result = new List<long>();
            long sum = 0;
            for (long i = 2; ; i += 2) switch (finalSum - sum - i)
                {
                    case > 0: result.Add(i); sum += i; break;
                    case 0: result.Add(i); goto LoopEnd;
                    case < 0: result[^1] += finalSum - sum; goto LoopEnd;
                }
            LoopEnd:;

            return result;
        }
    }
}
