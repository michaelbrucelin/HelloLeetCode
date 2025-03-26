using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3467
{
    public class Solution3467 : Interface3467
    {
        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] TransformArray(int[] nums)
        {
            int len = nums.Length;
            int[] freq = new int[2];
            for (int i = 0; i < len; i++) freq[nums[i] & 1]++;

            int[] result = new int[len];
            for (int i = freq[0]; i < len; i++) result[i] = 1;

            return result;
        }
    }
}
