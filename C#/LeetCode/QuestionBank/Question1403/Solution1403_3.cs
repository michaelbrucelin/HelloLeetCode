using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1403
{
    public class Solution1403_3 : Interface1403
    {
        /// <summary>
        /// 大顶堆
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> MinSubsequence(int[] nums)
        {
            List<int> result = new List<int>();
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            int target = 0, sum = 0;
            foreach (int num in nums)
            {
                target += num;
                maxpq.Enqueue(num, -num);
            }
            target >>= 1;

            while (sum <= target)
            {
                result.Add(maxpq.Dequeue());
                sum += result[^1];
            }

            return result;
        }
    }
}
