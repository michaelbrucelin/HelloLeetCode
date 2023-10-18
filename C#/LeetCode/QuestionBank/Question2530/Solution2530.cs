using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2530
{
    public class Solution2530 : Interface2530
    {
        /// <summary>
        /// 优先级队列，即最大堆
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaxKelements(int[] nums, int k)
        {
            long result = 0;
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            foreach (int num in nums) maxpq.Enqueue(num, -num);
            while (k-- > 0)
            {
                int num = maxpq.Dequeue();
                if (num > 1)
                {
                    result += num;
                    var t = Math.DivRem(num, 3);
                    num = t.Quotient + (t.Remainder != 0 ? 1 : 0);
                    maxpq.Enqueue(num, -num);
                }
                else  // num == 1
                {
                    result += k + 1;
                    break;
                }
            }

            return result;
        }
    }
}
