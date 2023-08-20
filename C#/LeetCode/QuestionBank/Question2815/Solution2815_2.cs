using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2815
{
    public class Solution2815_2 : Interface2815
    {
        /// <summary>
        /// 桶 + 优先级队列
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSum(int[] nums)
        {
            PriorityQueue<int, int>[] buckets = new PriorityQueue<int, int>[9];
            for (int i = 0; i < 9; i++) buckets[i] = new PriorityQueue<int, int>();

            foreach (int num in nums) buckets[MaxDigit(num) - 1].Enqueue(num, -num);

            int result = -1;
            for (int i = 0; i < 9; i++) if (buckets[i].Count > 1)
                {
                    result = Math.Max(result, buckets[i].Dequeue() + buckets[i].Dequeue());
                }
            return result;
        }

        /// <summary>
        /// 同MaxSum()，由于只需要两个最大值求和，所以将优先级队列改为两个变量
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSum2(int[] nums)
        {
            int[,] buckets = new int[9, 2];
            foreach (int num in nums)
            {
                int bid = MaxDigit(num) - 1;
                if (num > buckets[bid, 0])
                {
                    buckets[bid, 1] = buckets[bid, 0]; buckets[bid, 0] = num;
                }
                else if (num > buckets[bid, 1])
                {
                    buckets[bid, 1] = num;
                }
            }

            int result = -1;
            for (int i = 0; i < 9; i++) if (buckets[i, 1] > 0)
                {
                    result = Math.Max(result, buckets[i, 0] + buckets[i, 1]);
                }
            return result;
        }

        private int MaxDigit(int num)
        {
            int digit = 0;
            while (num > 0)
            {
                digit = Math.Max(digit, num % 10); num /= 10;
            }

            return digit;
        }
    }
}
