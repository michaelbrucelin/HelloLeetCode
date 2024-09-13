using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2398
{
    public class Solution2398_3 : Interface2398
    {
        /// <summary>
        /// 双指针 + 单调队列
        /// 逻辑同官解，相当于在双指针移动的同时，搞定了Solution2398中的线段树与前缀和数组
        /// 
        /// 写的不对，先不弄了，下次再说
        /// </summary>
        /// <param name="chargeTimes"></param>
        /// <param name="runningCosts"></param>
        /// <param name="budget"></param>
        /// <returns></returns>
        public int MaximumRobots(int[] chargeTimes, int[] runningCosts, long budget)
        {
            int result = 0, pl = 0, pr = 0, len = chargeTimes.Length; long sum = runningCosts[0];
            LinkedList<int> queue = new LinkedList<int>([chargeTimes[0]]);
            while (pl < len)
            {
                if (pr < pl)
                {
                    sum += runningCosts[pr = pl];
                    queue.AddLast(chargeTimes[pr]);
                }
                while (pr < len && queue.First.Value + (pr - pl + 1) * sum <= budget)
                {
                    result = Math.Max(result, pr - pl + 1);
                    if (pr + 1 < len)
                    {
                        sum += runningCosts[++pr];
                        while (queue.Count > 0 && runningCosts[pr] > queue.Last.Value) queue.RemoveLast();
                        queue.AddLast(runningCosts[pr]);
                    }
                    else
                    {
                        goto End;
                    }
                }

                sum -= runningCosts[pl];
                if (queue.First.Value == chargeTimes[pl]) queue.RemoveFirst();
                pl++;
            }
            End:;

            return result;
        }
    }
}
