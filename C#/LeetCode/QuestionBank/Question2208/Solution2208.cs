using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2208
{
    public class Solution2208 : Interface2208
    {
        /// <summary>
        /// 最大堆
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int HalveArray(int[] nums)
        {
            PriorityQueue<decimal, decimal> pqmax = new PriorityQueue<decimal, decimal>();
            decimal sum = 0, item;
            for (int i = 0; i < nums.Length; i++)
            {
                pqmax.Enqueue(nums[i], -nums[i]); sum += nums[i];
            }
            sum /= 2;

            int result = 0;
            while (sum > 0)
            {
                item = pqmax.Dequeue();
                item /= 2;
                pqmax.Enqueue(item, -item);
                sum -= item;
                result++;
            }

            return result;
        }

        /// <summary>
        /// 与HalveArray()一模一样，只是将decimal改为double试试，看看会不会产生精度问题
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int HalveArray2(int[] nums)
        {
            PriorityQueue<double, double> pqmax = new PriorityQueue<double, double>();
            double sum = 0, item;
            for (int i = 0; i < nums.Length; i++)
            {
                pqmax.Enqueue(nums[i], -nums[i]); sum += nums[i];
            }
            sum /= 2;

            int result = 0;
            while (sum > 0)
            {
                item = pqmax.Dequeue();
                item /= 2;
                pqmax.Enqueue(item, -item);
                sum -= item;
                result++;
            }

            return result;
        }
    }
}
