using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2208
{
    public class Solution2208_oth : Interface2208
    {
        public int HalveArray(int[] nums)
        {
            PriorityQueue<long, long> pqmax = new PriorityQueue<long, long>();
            long sum = 0, item;
            for (int i = 0; i < nums.Length; i++)
            {
                item = (long)nums[i] << 20;
                pqmax.Enqueue(item, -item);
                sum += item;
            }
            sum >>= 1;

            int result = 0;
            while (sum > 0)
            {
                item = pqmax.Dequeue();
                item >>= 1;
                pqmax.Enqueue(item, -item);
                sum -= item;
                result++;
            }
            return result;
        }
    }
}
