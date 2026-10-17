
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3781
{
    public class Solution3781 : Interface3781
    {
        /// <summary>
        /// 大顶堆
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public long MaximumScore(int[] nums, string s)
        {
            long result = 0; int len = s.Length;
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            for (int i = 0; i < len; i++)
            {
                maxpq.Enqueue(nums[i], -nums[i]);
                if (s[i] != '0') result += maxpq.Dequeue();
            }

            return result;
        }
    }
}
