using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCS.LCS0002
{
    public class Solution0002 : Interface0002
    {
        /// <summary>
        /// 计数 + 优先级队列
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        public int HalfQuestions(int[] questions)
        {
            int len = questions.Length;
            Dictionary<int, int> freqs = new Dictionary<int, int>();
            foreach (int i in questions)
            {
                freqs.TryAdd(i, 0); freqs[i]++;
            }
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            foreach (int freq in freqs.Values) maxpq.Enqueue(freq, -freq);

            int result = 0, sum = 0, limit = len >> 1;
            while (sum < limit)
            {
                sum += maxpq.Dequeue(); result++;
            }

            return result;
        }
    }
}
