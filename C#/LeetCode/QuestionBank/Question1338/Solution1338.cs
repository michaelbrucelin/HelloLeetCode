using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1338
{
    public class Solution1338 : Interface1338
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MinSetSize(int[] arr)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (int num in arr)
            {
                if (freq.ContainsKey(num)) freq[num]++; else freq.Add(num, 1);
            }
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            foreach (int cnt in freq.Values) maxpq.Enqueue(cnt, -cnt);

            int result = 0, tar = (arr.Length + 1) >> 1, _cnt = 0;
            while (_cnt < tar)
            {
                _cnt += maxpq.Dequeue(); result++;
            }

            return result;
        }
    }
}
