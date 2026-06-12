using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1833
{
    public class Solution1833_2 : Interface1833
    {
        /// <summary>
        /// 堆
        /// </summary>
        /// <param name="costs"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int MaxIceCream(int[] costs, int coins)
        {
            int result = 0, sum = 0, len = costs.Length;
            PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
            for (int i = 0; i < len; i++) minpq.Enqueue(costs[i], costs[i]);
            while (minpq.Count > 0)
            {
                result++;
                if ((sum += minpq.Dequeue()) > coins) { result--; break; }
            }

            return result;
        }
    }
}
