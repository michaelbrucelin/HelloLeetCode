using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0480
{
    public class Solution0480 : Interface0480
    {
        /// <summary>
        /// 堆 + 懒删除
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            if (k == 1) return [.. nums];
            int len = nums.Length;
            double[] result = new double[len - k + 1];
            if (k == 2)
            {
                for (int i = 1; i < len; i++) result[i - 1] = (0D + nums[i - 1] + nums[i]) / 2;
                return result;
            }

            return result;
        }
    }
}
