using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3074
{
    public class Solution3074 : Interface3074
    {
        /// <summary>
        /// 贪心 + 优先级队列
        /// </summary>
        /// <param name="apple"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public int MinimumBoxes(int[] apple, int[] capacity)
        {
            int sum = 0;
            for (int i = 0; i < apple.Length; i++) sum += apple[i];
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            for (int i = 0; i < capacity.Length; i++) maxpq.Enqueue(capacity[i], -capacity[i]);

            int result = 0, _sum = 0;
            while (_sum < sum) { _sum += maxpq.Dequeue(); result++; }

            return result;
        }
    }
}
